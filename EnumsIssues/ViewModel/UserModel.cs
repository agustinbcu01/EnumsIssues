using EnumsIssues.Entities;

namespace EnumsIssues.ViewModel
{
  public class UserModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public StatusEnum Status { get; set; }
    public UserModel() { }
    public UserModel(User user)
    {

      Id = user.Id;
      Name = user.Name;
      Email = user.Email;
      PasswordHash = user.PasswordHash;
      Status = user.Status;

    }
    public User CreateIntity()
    {
      return new User
      {
        Id = Id,
        Name = Name,
        Email = Email,
        PasswordHash = PasswordHash,
        Status = Status
      };
    }
  }
}

