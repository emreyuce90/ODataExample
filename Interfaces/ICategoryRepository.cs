using ODataExample.Models;

namespace ODataExample.Interfaces {
    public interface ICategoryRepository {
        Task<bool> AddAsync(Category category);
    }
}
