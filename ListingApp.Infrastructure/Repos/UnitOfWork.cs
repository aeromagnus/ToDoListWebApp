using ListingApp.DAL.Entity;
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
        private ILoginRepo _loginRepo;
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
        public ILoginRepo loginRepo
        {
            get
            {
                if (this._loginRepo == null)
                {
                    this._loginRepo = new LoginRepo(_context);
                }
                return _loginRepo;
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
