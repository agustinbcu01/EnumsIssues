using EnumsIssues.Entities;
using EnumsIssues.ViewModel;

namespace EnumsIssues.Services
{
  public interface IUserService
  {
    UserModel[] GetAllActive(); 
    int Create (UserModel model);
  }
  public class UserService : IUserService
  {
    private readonly UnumsContext _context;

    public UserService(UnumsContext context)
    {
      _context = context;
    }

    public int Create(UserModel model)
    {
      _context.User.Add(model.CreateIntity());
      _context.SaveChanges();
      return model.Id;
    }

    public UserModel[] GetAllActive()
    {
      
      return _context.User.Where(x => x.Status == StatusEnum.Active).Select(x => new UserModel(x)).ToArray();
      
    }
  }
}
