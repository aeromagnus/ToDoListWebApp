using ListingApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.DAL.Repository
{
    public class toDoListRepo:IDisposable, ItoDoListRepo
    {
        private bool disposedValue;
    private readonly crudContext _context;

    public toDoListRepo(crudContext Context)
    {
        _context = Context;
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

    public IEnumerable<toDoList> Getlists()
    {
        return _context.toDoList.ToList();
    }

    public toDoList GetListById(int listId)
    {
        return _context.toDoList.Find(listId);
    }

    public void InsertList(toDoList Record)
    {
        _context.toDoList.Add(Record);
    }

    public void DeleteList(int listID)
    {
        var Result = _context.toDoList.Find(listID);
        _context.toDoList.Remove(Result);
    }

    public void UpdateList(toDoList Record)
    {
        _context.Entry(Record).State = EntityState.Modified;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
}
