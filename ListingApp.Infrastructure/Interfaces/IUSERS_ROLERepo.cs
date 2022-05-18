using ListingApp.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface IUSERS_ROLERepo
    {
        string Insert(USERS_ROLEVM data);
        void Update(USERS_ROLEVM data);
        bool Delete(int catID);
        List<USERS_ROLEVM> GetAll();
        USERS_ROLEVM GetByID(int catID);
    }

}
