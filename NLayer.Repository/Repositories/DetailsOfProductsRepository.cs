using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class DetailsOfProductsRepository : GenericRepository<DetailsOfProduct>, IDetailsOfProductsRepository
    {
        public DetailsOfProductsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<DetailsOfProduct>> GetDetailsByProductId()
        {
            return await _context.DetailsOfProducts.Include(x => x.Product).ToListAsync();   
        }
    }
}
