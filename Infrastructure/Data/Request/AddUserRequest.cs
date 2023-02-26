namespace App.Infrastructure.Data.Request;

public class AddUserRequest
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
}