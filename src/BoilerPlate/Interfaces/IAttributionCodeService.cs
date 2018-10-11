using BoilerPlate.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlate.Interfaces
{
    public interface IAttributionCodeService
    {
        List<AttributionCode> GetAllAttributionCodes();
    }
}
