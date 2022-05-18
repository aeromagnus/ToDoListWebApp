using ListingApp.DAL.Entity;
using ListingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ListingApp.BusinessObjects;
using ServiceStack;

namespace ListingApp.Infrastructure.Repos
{
    public class todoListRepo: ItodoListRepo
    {
      
        protected crudContext _context;
        //parameterized constructors 
      
        public todoListRepo(crudContext context)
        {
           
            _context = context;
        }

        public List<toDoListVM> Getlists()
        {
           
               
                var data = Mapper.convert(_context.toDoList.ToList());
                return data;

           
        }

        public toDoListVM GetListById(int listId)
        {
            try
            {
                var data = _context.toDoList.Find(listId);
                return Mapper.convert(data);
            }
            catch 
            { 
                return new toDoListVM(); 
            }
        }

        public void InsertList(toDoListVM data)
        {
            try
            {
                toDoList entity = new toDoList();
                entity = Mapper.convert(data);
                entity.CreatedOn = DateTime.Now;
                 _context.toDoList.Add(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public bool DeleteList(int listID)
        {
            try
            {
                var Result = _context.toDoList.Find(listID);
                if (Result == null)
                { 
                    return false;
                }
                else
                {
                    Result.is_Deleted = true;
                    //_context.toDoList.Remove(Result);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch /*(Exception ex)*/
            {
                //throw ex.InnerException;
                return false;
            }
        }

        public void UpdateList(toDoListVM data)
        {
            try
            {
                if (data == null)
                {
                    throw null;
                }
                else
                {
                    toDoList record = Mapper.convert(data);
                    toDoList existing = _context.toDoList.Find(data.toDoListID);
                    //list = Mapper.convert(Record);
                    if (existing !=null)
                    {
                        _context.Entry(existing).State = System.Data.Entity.EntityState.Detached;
                        _context.toDoList.Attach(record);
                        _context.Entry(record).State = System.Data.Entity.EntityState.Modified;
                        _context.SaveChanges();
                    }
                }
        
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
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
