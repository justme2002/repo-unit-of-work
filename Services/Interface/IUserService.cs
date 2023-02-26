using App.Infrastructure.Data.Request;
using App.Infrastructure.Data.Response;

namespace App.Services.Interface;

public interface IUserService
{ 
  public Task<AddUserResponse> AddUserAsync(AddUserRequest AddUserRequest);
}