using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeathRobotics.Engineering.UnitConversion.Api.Models.Length;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace HeathRobotics.Engineering.UnitConversion.Api.Controllers
{
    [ApiController]
    [Route("api/unit_conversion/length")]
    public class LengthController
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
                    cfg.CreateMap<LengthMeasureModel, LengthMeasure>();
                    cfg.CreateMap<LengthMeasure, LengthMeasureModel>();

                });
            this.mapper = new Mapper(mapperConfiguration);
            #endregion
        }

        [HttpPost]
        public ActionResult<LengthMeasureModel> Convert([FromBody] LengthMeasureModel apiModel)
        {
            var dslModel = this.mapper.Map<LengthMeasureModel, LengthMeasure>(apiModel);
            dslModel.Prefix = PrefixUnits.None; //todo
            dslModel.Units = LengthUnits.Feet; //todo

            var result = this.unitConversionService.ConvertLength(dslModel, PrefixUnits.None, LengthUnits.Meters, 3);
            var response = this.mapper.Map<LengthMeasure, LengthMeasureModel>(result);
            return response;
        }
    }
}
