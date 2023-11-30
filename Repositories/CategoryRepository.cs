using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AdoNet1Context _DbContext;
        public CategoryRepository(AdoNet1Context dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _DbContext.Categories.ToListAsync();
        }
    }
}
