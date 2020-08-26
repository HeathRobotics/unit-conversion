using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeathRobotics.Engineering.UnitConversion.Api.Models.Length;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Core;

namespace HeathRobotics.Engineering.UnitConversion.Api.Controllers
{
    [ApiController]
    [Route("api/unit_conversion/length")]
    public class LengthController : ControllerBase
    {
        private readonly ILogger<LengthController> logger;
        private readonly IAggregateUnitConversionService unitConversionService;
        private IMapper mapper;

        public LengthController(ILogger<LengthController> logger, IAggregateUnitConversionService unitConversionService)
        {
            logger = logger;
            this.unitConversionService = unitConversionService;

            #region mapper configuration
            var mapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<LengthMeasureConversionModel, LengthMeasure>()
                    .ForMember(dest => dest.Prefix, opt => opt.MapFrom(src => Enum.Parse(typeof(PrefixUnits), src.Prefix, true)))
                    .ForMember(dest => dest.Units, opt => opt.MapFrom(src => Enum.Parse(typeof(LengthUnits), src.Units, true)));
                    cfg.CreateMap<LengthMeasure, LengthMeasureConversionModel>()
                    .ForMember(dest => dest.Prefix, opt => opt.MapFrom(src => src.Prefix.ToString().ToLower()))
                    .ForMember(dest => dest.Units, opt => opt.MapFrom(src => src.Units.ToString().ToLower()));

                });
            this.mapper = new Mapper(mapperConfiguration);
            #endregion
        }

        [HttpPost]
        public ActionResult<LengthMeasureConversionModel> Convert([FromBody] LengthMeasureConversionModel apiModel)
        {
            var dslModel = this.mapper.Map<LengthMeasureConversionModel, LengthMeasure>(apiModel);

            if (string.IsNullOrWhiteSpace(apiModel.TargetPrefix))
            {
                return BadRequest("A target prefix is required.");
            }

            if (string.IsNullOrWhiteSpace(apiModel.TargetUnits))
            {
                return BadRequest("A target prefix is required.");
            }

            var targetPrefix = (PrefixUnits)Enum.Parse(typeof(PrefixUnits), apiModel.TargetPrefix, true);
            var targetUnits = (LengthUnits)Enum.Parse(typeof(LengthUnits), apiModel.TargetUnits, true);
            var targetPrecision = apiModel.Precision.HasValue ? apiModel.Precision.Value : 3;

            var result = this.unitConversionService.ConvertLength(dslModel, targetPrefix, targetUnits, targetPrecision);
            var response = this.mapper.Map<LengthMeasure, LengthMeasureConversionModel>(result);
            return response;
        }
    }
}
