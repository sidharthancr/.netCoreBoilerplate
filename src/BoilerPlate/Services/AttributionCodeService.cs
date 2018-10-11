using BoilerPlate.Contract;
using BoilerPlate.DataAccess.Interfaces;
using BoilerPlate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlate.Services
{
    public class AttributionCodeService : IAttributionCodeService
    {
        IAttributionCodeRepository _attributionRepository;

       public AttributionCodeService(IAttributionCodeRepository attributionCodeRepository)
        {
            _attributionRepository = attributionCodeRepository;
        }
        public List<AttributionCode> GetAllAttributionCodes()
        {
            return _attributionRepository.GetAllAttributionCodes();
        }
    }
}
