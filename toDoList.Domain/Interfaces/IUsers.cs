using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDoList.Domain.Interfaces
{
    public interface IUsers:IDisposable
    {
        IEnumerable<users> GetUsers();
        users GetUsersByID(int userId);
        void InsertUsers(users Record);
        void DeleteUsers(int userID);
        void UpdateUsers(users Record);
        void Save();
    }
}
