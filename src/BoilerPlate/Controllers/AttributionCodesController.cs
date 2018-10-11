using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.Contract;
using BoilerPlate.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    public class AttributionCodesController : ControllerBase
    {
        IAttributionCodeService _attributionCodeService;
        public AttributionCodesController(IAttributionCodeService attributionCodeService)
        {
            _attributionCodeService = attributionCodeService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<AttributionCode>> Get()
        {
            return _attributionCodeService.GetAllAttributionCodes(); ;
        }
    }
}
