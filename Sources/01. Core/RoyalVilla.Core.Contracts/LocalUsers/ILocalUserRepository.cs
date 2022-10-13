using RoyalVilla.Core.Contracts.Common;
using RoyalVilla.Core.Entities.LocalUsers;
using System.Runtime.CompilerServices;

namespace RoyalVilla.Core.Contracts.LocalUsers;

public interface ILocalUserRepository : IBaseRepository<LocalUser>
{
    Task<LocalUser> UpdateAsync(LocalUser entity);
    //Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    //public bool IsUniqueUser { get; set; }
}
