using Exam.API.Models;

namespace Exam.API.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        //bool FindByUser(int id);
    }
}
