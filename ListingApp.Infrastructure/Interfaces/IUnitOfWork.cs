using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IusersRepo usersRepo { get; }
        ItodoListRepo toDoListRepo { get; }
        ILoginRepo loginRepo { get; }
        void Save();
    }
}
