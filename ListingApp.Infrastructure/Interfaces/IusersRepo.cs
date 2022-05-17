using ListingApp.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface IusersRepo : IDisposable
    {
        List<usersVM> GetUsers();
        usersVM GetUsersByID(int userId);
        void InsertUsers(usersVM Record);
        void DeleteUsers(int userID);
        void UpdateUsers(usersVM Record);
        string checkpass(int userid,string pass);
        void Save();
    }
}
