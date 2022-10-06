using RoyalVilla.Endpoints.VillaWeb.Models;

namespace RoyalVilla.Endpoints.VillaWeb.Services.IServices;

public interface IBaseService
{
    APIResponse responseModel { get; set; }
    Task<T> SendAsync<T>(APIRequest apiRequest);
}
