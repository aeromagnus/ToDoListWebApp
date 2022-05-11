using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.Repository.ViewModel;

namespace toDoList.Repository.Interfaces
{
    public interface IListNameServices
    {
        List<todoListVM> GetAll();
        todoListVM Get(int listId);
        string insertList(todoListVM Record);
        string updateList(todoListVM Record);
        bool deleteList(int listID);


    }
}
