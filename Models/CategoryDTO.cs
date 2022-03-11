using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name cannot be empty!")]
        public string Name { get; set; }
    }
}
