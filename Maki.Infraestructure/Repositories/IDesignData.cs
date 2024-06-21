using System.Collections.Generic;
using System.Threading.Tasks;
using _3_Data.Models;

namespace _3_Data.Models;

    public interface IDesignData
    {
        Task<List<Design>> GetAllAsync();
        Task<Design> GetByIdAsync(int id);
        Task<Design> GetByNameAsync(string name); // Este método acepta un string y devuelve un DesignData
        Task<int> SaveAsync(Design design); // Guardar DesignData y devolver el Id
        
        Task<bool> DeleteAsync(int id);
    }
