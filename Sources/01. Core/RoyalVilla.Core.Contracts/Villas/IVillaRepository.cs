using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.Villas;

namespace RoyalVilla.Core.Contracts.Villas;

public interface IVillaRepository : IBaseRepository<Villa>
{
    Task<Villa> UpdateAsync(Villa entity);
}
