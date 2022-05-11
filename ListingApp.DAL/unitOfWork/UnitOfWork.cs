using ListingApp.DAL.Interfaces;
using ListingApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.DAL.unitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly crudContext _context;
        private IusersRepo _usersRepo;
        private ItoDoListRepo _listRepo;
        public UnitOfWork()
        {
            _context = new crudContext();
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

        public ItoDoListRepo listNameRepo
        {
            get
            {
                if (this._listRepo == null)
                {
                    this._listRepo = new toDoListRepo(_context);
                }
                return _listRepo;
            }
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
