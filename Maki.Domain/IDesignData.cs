using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3_Data
{
    public interface IDesignData
    {
        Task<List<DesignData>> GetAllAsync();
        Task<DesignData> GetByIdAsync(int id);
        Task CreateAsync(DesignData design);
        Task DeleteAsync(int id);
    }
}
