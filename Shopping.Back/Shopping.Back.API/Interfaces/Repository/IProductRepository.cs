using Shopping.API.Data.ValueObjects;

namespace Shopping.API.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> ListAll();
        Task<ProductVO> FindById(int id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(int id);
    }
}
