
using System;

namespace Exam.API.Interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        int Complete();
        IUserRepository UserRepository { get; set; }
    }
}
