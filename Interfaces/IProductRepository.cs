using ODataExample.Models;

namespace ODataExample.Interfaces {
    public interface IProductRepository {
        Task<bool> AddAsync(Product product);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    }
}
