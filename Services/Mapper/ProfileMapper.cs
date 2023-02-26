using App.Infrastructure.Data.Request;
using App.Infrastructure.Entity;
using AutoMapper;

namespace App.Services.Mapper;

public class ProfileMapper : Profile
{
  public ProfileMapper() : base()
  {
    CreateMap<AddUserRequest, User>();
    CreateMap<User, AddUserRequest>();
  }
}

