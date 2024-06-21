using _3_Data.Contexts;
using _3_Data.Models;
using Microsoft.EntityFrameworkCore;



namespace _3_Data;


    public class DesignData : IDesignData
    {
        private MakiContext _makiContext;

        public DesignData(MakiContext makiContext)
        {
            _makiContext = makiContext;
        }

        public async Task<List<Design>> GetAllAsync()
        {
            return await _makiContext.Designs.ToListAsync();
        }

        public async Task<Design> GetByIdAsync(int id)
        {
            return await _makiContext.Designs.FindAsync(id);
        }

        public async Task<Design> GetByNameAsync(string name)
        {
            return await _makiContext.Designs.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<int> SaveAsync(Design design)
        {
            _makiContext.Designs.Add(design);
            await _makiContext.SaveChangesAsync();
            return design.Id;
        }
        public async Task<int> CreateAsync(Design design)
        {
            _makiContext.Designs.Add(design);
            await _makiContext.SaveChangesAsync();
            return design.Id;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var design = await _makiContext.Designs.FindAsync(id);
            if (design != null)
            {
                _makiContext.Designs.Remove(design);
                await _makiContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
