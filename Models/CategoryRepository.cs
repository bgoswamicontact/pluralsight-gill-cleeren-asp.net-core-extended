using System.Collections.Generic;

namespace BethenysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public IEnumerable<Category> AllCategories {
            get
            {
                return _appDbContext.Categories;
            }
        }
    }
}
