using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.LocalUsers;

namespace RoyalVilla.Core.Contracts.LocalUsers;

public interface ILocalUserRepository : IBaseRepository<LocalUser>
{
    Task<LocalUser> UpdateAsync(LocalUser entity);
}
