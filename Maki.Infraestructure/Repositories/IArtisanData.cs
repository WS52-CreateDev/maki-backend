using _3_Data.Models;

namespace _3_Data;

public interface IArtisanData
{
    Task<bool> SaveAsync(Artisan data);
    Task<Artisan> GetByEmailAsync(string name);
    Task<bool> UpdateAsync(int id, Artisan data);
    Task<bool> DeleteAsync(int id);
    Task<Artisan> GetByIdAsync(int id);
    Task<IEnumerable<Artisan>> GetAllAsync();
    
}