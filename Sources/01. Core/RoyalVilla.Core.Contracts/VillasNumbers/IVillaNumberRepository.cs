using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.VillasNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalVilla.Core.Contracts.VillasNumbers;

public interface IVillaNumberRepository : IBaseRepository<VillaNumber>
{
    Task<VillaNumber> UpdateAsync(VillaNumber entity);
}
