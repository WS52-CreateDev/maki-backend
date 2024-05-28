using _3_Data.Models;

namespace _2_Domain;

public interface ICategoryDomain
{
    Task<bool> SaveAsync(Category data);

    Task<bool> UpdateAsync(Category data, int id);

    Task<bool> DeleteAsync(int id);
}