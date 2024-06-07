using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3_Data.Models
{
    public interface IDesignData
    {
        Task<List<DesignData>> GetAllAsync();
        
        Task<DesignData> GetByIdAsync(int id);
        
        Task<DesignData> GetByNameAsync(string name);
        
        Task<int> SaveAsync(DesignData data);
        
        Task<bool> UpdateAsync(DesignData data, int id);
        
        Task<bool> DeleteAsync(int id);
    }
}
