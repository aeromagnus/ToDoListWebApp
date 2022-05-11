using ListingApp.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface ItoDoListServices
    {
        List<toDoListDTO> GetAll();
        toDoListDTO Get(int listId);
        string insertList(toDoListDTO Record);
        string updateList(toDoListDTO Record);
        bool deleteList(int listID);
    }
}
