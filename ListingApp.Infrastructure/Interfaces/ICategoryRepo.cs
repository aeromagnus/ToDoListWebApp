using ListingApp.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface ICategoryRepo:IDisposable
    {
        string Insert(CategoryVM data);
        void Update(CategoryVM data);
        bool Delete(int catID);
        List<CategoryVM> GetAll();
        CategoryVM GetByID(int catID);
    }
}
