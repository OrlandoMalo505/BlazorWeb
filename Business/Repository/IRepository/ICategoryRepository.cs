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
        public  Task<CategoryDTO> Create(CategoryDTO objDTO);
        public  Task<CategoryDTO> Update(CategoryDTO objDTO);  
        public  Task<IEnumerable<CategoryDTO>> GetAll();
        public  Task<CategoryDTO> Get(int id);
        public  Task<int> Delete(int id);

    }
}
