using ListingApp.BusinessObjects;
using ListingApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface ItodoListRepo:IDisposable
    {
        List<toDoListVM> Getlists();
        toDoListVM GetListById(int listId);
        void InsertList(toDoListVM Record);
        bool DeleteList(int listID);
        void UpdateList(toDoListVM Record);

      
        void Save();

        //List<toDoList> List();
        //toDoList GetByID(int listId);
        //void InsertList(toDoList Record);


    }
}
