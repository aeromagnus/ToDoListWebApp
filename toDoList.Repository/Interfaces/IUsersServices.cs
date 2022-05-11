using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.Repository.ViewModel;

namespace toDoList.Repository.Interfaces
{
    public interface IUsersServices
    {
        usersVM Get(usersVM users);
        string Add(usersVM Record);
        string Delete(int userId);
        string Update(usersVM Record);
        List<usersVM> GetAll();
    }
}
