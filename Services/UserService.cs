using App.Services.Interface;
using App.Infrastructure;
using App.Infrastructure.Repositories;
using App.Infrastructure.Data.Response;
using App.Infrastructure.Data;
using App.Infrastructure.Data.Request;
using AutoMapper;
using App.Infrastructure.Entity;
using App.Infrastructure.Interface;

namespace App.Services;

public class UserService : IUserService
{
  private IMapper Mapper;
  private readonly IUnitOfWork unitOfWork;
  private readonly IUserRepository userRepository;
  public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper Mapper)
  {
    this.unitOfWork = unitOfWork;
    this.userRepository = userRepository;
    this.Mapper = Mapper;
  }
  public async Task<AddUserResponse> AddUserAsync(AddUserRequest AddUserRequest)
  {
    try
    {
      User MapAddUser = Mapper.Map<AddUserRequest, User>(AddUserRequest);
      this.unitOfWork.BeginTransactionAsync();
      var result = await this.userRepository.Add(MapAddUser);
      await this.unitOfWork.CommitTransactionAsync();
      if (result != true)
      {
        return new AddUserResponse
        {
          Status = false,
          Message = "Error to create"
        };
      }
      return new AddUserResponse
      {
        Status = true,
        Message = "Success to add"
      };
    }
    catch (System.Exception e)
    {
      
      throw e;
    }
  }
}