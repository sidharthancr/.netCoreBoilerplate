using BoilerPlate.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoilerPlate.DataAccess.Interfaces
{
    public interface IAttributionCodeRepository
    {
        List<AttributionCode> GetAllAttributionCodes();
    }
}
