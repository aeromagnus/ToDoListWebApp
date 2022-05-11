using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoList.Domain.Interfaces;

namespace toDoList.Domain.Repos
{
    public class Users : IUsers, IDisposable
    {
        private readonly crudEntities _context;
        private bool disposedValue;

        public Users(crudEntities _context)
        {
            _context = new crudEntities();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ListName()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<users> GetUsers()
        {
            return _context.users.ToList();
        }

        public users GetUsersByID(int userId)
        {
            return _context.users.Find(userId);
        }

        public void InsertUsers(users Record)
        {
            _context.users.Add(Record);
        }

        public void DeleteUsers(int userID)
        {
            users Result = _context.users.Find(userID);
            _context.users.Remove(Result);
        }

        public void UpdateUsers(users Record)
        {
            _context.Entry(Record).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
