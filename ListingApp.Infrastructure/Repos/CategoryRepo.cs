using ListingApp.BusinessObjects;
using ListingApp.DAL.Entity;
using ListingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListingApp.Infrastructure.Repos
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly crudContext _context;
        public CategoryRepo(crudContext Context)
        {
            _context = Context;
        }
        public string Insert(CategoryVM data)
        {
            try
            {
                var result = new Category();
                result = Mapper.convert(data);
                _context.Category.Add(result);
                _context.SaveChanges();
                return "Successfully Added Category to the db";
            }
            catch (Exception ex)
            {
                throw ex.InnerException;    
            }
        }
    }
}
