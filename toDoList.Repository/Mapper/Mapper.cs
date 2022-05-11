using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.DAL.Interfaces;
using toDoList.Repository.ViewModel;
using toDoList.DAL;

namespace toDoList.Repository.Mapper
{
    public class Mapper
    {
        private readonly IListNameRepo _listName;
        private readonly IUnitOfWork _unitofWork;

        public Mapper(IUnitOfWork unitofWork, IListNameRepo listName)
        {
            _listName = listName;
            _unitofWork = unitofWork;

        }

        public static todoListVM Convert(toDoList entity)
        { 
        
        }
        
    }
}
