using CompanyDemo.Models;

namespace CompanyDemo.Interfaces;

public interface IUserRepository
{
    User Find(string email, string password);
    List<User> GetAll();
    User Create(User user);

    User Update(User user);

    void Delete(int id);
}