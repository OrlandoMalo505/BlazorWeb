using AutoMapper;
using Business.Mapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public CategoryDTO Create(CategoryDTO objDTO)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(objDTO);
            category.CreatedDate = DateTime.Now;    
            _db.Categories.Add(category);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public int Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(category != null)
            {
                _db.Categories.Remove(category);
                return _db.SaveChanges();
            }
            return 0;
            
        }

        public CategoryDTO Get(int id)
        {
            var category = _db.Categories.SingleOrDefault(c => c.Id == id);
            if(category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }
            return new CategoryDTO();

        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == objDTO.Id);
            if(categoryFromDb != null)
            {
                categoryFromDb.Name = objDTO.Name;
                _db.Categories.Update(categoryFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDTO>(categoryFromDb);
            }
            return objDTO;

        }
    }
}
