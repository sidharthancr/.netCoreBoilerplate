using BoilerPlate.Contract;
using BoilerPlate.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoilerPlate.DataAccess
{
   public class AttributionCodeRepository : IAttributionCodeRepository
    {
        private DatabaseContext _context;
        public AttributionCodeRepository(DatabaseContext context)
        {
            _context = context;
        }
        public List<AttributionCode> GetAllAttributionCodes()
        {
            return _context.AttributionCode.Take(5).ToList();
        }
    }
}
