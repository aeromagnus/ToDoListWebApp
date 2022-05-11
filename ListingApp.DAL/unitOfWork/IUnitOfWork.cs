using ListingApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.DAL.unitOfWork
{
    public interface IUnitOfWork
    {
        IusersRepo usersRepo { get; }
        ItoDoListRepo toDoListRepo { get; }
        int SaveChanges();
    }
}
