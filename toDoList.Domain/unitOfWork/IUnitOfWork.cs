using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.Domain.Repos;

namespace toDoList.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
         IUsers usersRepo { get; }
         IListName listNameRepo { get; }
        int SaveChanges();
    }
}
