using _3_Data.Contexts;
using _3_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Data;

public class ArtisanData : IArtisanData
{
    private MakiContext _makiContext;

    public ArtisanData(MakiContext makiContext)
    {
        _makiContext = makiContext;
    }

    public async Task<bool> SaveAsync(Artisan data)
    {
        var strategy = _makiContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _makiContext.Database.BeginTransactionAsync();
            await _makiContext.Artisans.AddAsync(data);
            await _makiContext.SaveChangesAsync();
            await transaction.CommitAsync();
        });
        return true;
    }

    public async Task<Artisan> GetByEmailAsync(string email)
    {
        return await _makiContext.Artisans.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> UpdateAsync(int id, Artisan data)
    {
        var existingArtisan = _makiContext.Artisans.FirstOrDefault(x => x.Id == id);
        if (existingArtisan == null)
            return false;
        existingArtisan.Name = data.Name;
        existingArtisan.Surname = data.Surname;
        existingArtisan.Phone = data.Phone;
        existingArtisan.Address = data.Address;
        existingArtisan.Email = data.Email;
        existingArtisan.Photo = data.Photo;
        existingArtisan.Age = data.Age;
        existingArtisan.Province = data.Province;
        existingArtisan.Info = data.Info;
        existingArtisan.Password = data.Password;
        existingArtisan.BusinessName = data.BusinessName;
        existingArtisan.BusinessAddress = data.BusinessAddress;
        await _makiContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingArtisan = _makiContext.Artisans.FirstOrDefault(x => x.Id == id);
        if (existingArtisan == null)
            return false;
        
        _makiContext.Artisans.Remove(existingArtisan);
        await _makiContext.SaveChangesAsync();
        return true;
        
    }

    public async Task<Artisan> GetByIdAsync(int id)
    {
        return await _makiContext.Artisans.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Artisan>> GetAllAsync()
    {
        return await _makiContext.Artisans.ToListAsync();
    }
}