using ListingApp.DAL;
using ListingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Repos
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly crudContext _context;
        private IusersRepo _usersRepo;
        private ItodoListRepo _listRepo;
        public UnitOfWork()
        {
            _context = new crudContext();
        }

        public UnitOfWork(crudContext Context)
        {
            _context = Context;
        }

        public IusersRepo usersRepo
        {
            get
            {
                if (this._usersRepo == null)
                {
                    this._usersRepo = new usersRepo(_context);
                }
                return _usersRepo;
            }
        }

        public ItodoListRepo toDoListRepo
        {
            get
            {
                if (this._listRepo == null)
                {
                    this._listRepo = new todoListRepo(_context);
                }
                return _listRepo;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
