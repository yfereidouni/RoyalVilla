using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.VillasNumbers;

namespace RoyalVilla.Core.Contracts.VillasNumbers;

public interface IVillaNumberRepository : IBaseRepository<VillaNumber>
{
    Task<VillaNumber> UpdateAsync(VillaNumber entity);
}
