using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface IusersServices
    {
        usersVM Get(usersVM users);
        string Add(usersVM Record);
        string Delete(int userId);
        string Update(usersVM Record);
        List<usersVM> GetAll();
    }
}
