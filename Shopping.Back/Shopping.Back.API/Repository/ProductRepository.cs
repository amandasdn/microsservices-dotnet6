using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Data.ValueObjects;
using Shopping.API.Interfaces.Repository;
using Shopping.API.Model;
using Shopping.API.Model.Context;

namespace Shopping.Back.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLContext _context;
        private IMapper _mapper;

        public ProductRepository(SQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> ListAll()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            
            _context.Products.Add(product);
            
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == vo.Id);

            if (product == null) return null;

            Product productModified = _mapper.Map<Product>(vo);

            _context.Entry(product).CurrentValues.SetValues(productModified);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return _mapper.Map<ProductVO>(productModified);

            return null;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                // Check if product exists
                if (product == null) return false;

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
