using AutoMapper;
using Business.Mapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(objDTO);
            category.CreatedDate = DateTime.Now;
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public async Task<int> Delete(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                return await _db.SaveChangesAsync();
            }
            return 0;

        }

        public async Task<CategoryDTO> Get(int id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }
            return new CategoryDTO();

        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var categoryFromDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (categoryFromDb != null)
            {
                categoryFromDb.Name = objDTO.Name;
                _db.Categories.Update(categoryFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(categoryFromDb);
            }
            return objDTO;

        }


    }
}
