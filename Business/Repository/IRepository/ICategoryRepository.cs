using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDTO Create(CategoryDTO objDTO);
        public CategoryDTO Update(CategoryDTO objDTO);  
        public IEnumerable<CategoryDTO> GetAll();
        public CategoryDTO Get(int id);
        public int Delete(int id);

    }
}
