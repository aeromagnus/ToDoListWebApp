using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListingApp.Infrastructure.DTO
{
    public class toDoListDTO
    {
        public int toDoListID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
