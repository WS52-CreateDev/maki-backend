
using _3_Data.Models;

namespace _2_Domain;
public interface IDesignDomain
{
    Task<int> SaveAsync(Design data);

    Task<bool> DeleteAsync(int id);
}