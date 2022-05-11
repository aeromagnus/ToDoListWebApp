using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.Domain.Interfaces;

namespace toDoList.Domain.Repos
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly crudEntities _context;
        private IUsers _usersRepo;
        private IListName _listNameRepo;
        public UnitOfWork()
        {
            _context = new crudEntities();
        }


        public IUsers usersRepo
        {
            get
            {
                if (this._usersRepo == null)
                {
                    this._usersRepo = new Users(_context);
                }
                return _usersRepo;
            }
        }

        public IListName listNameRepo { get 
            {
                if (this._listNameRepo == null)
                {
                    this._listNameRepo = new ListName(_context);
                }
                return _listNameRepo;
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
