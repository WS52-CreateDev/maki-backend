using _3_Data;
using _3_Data.Models;

namespace _2_Domain;

public class ArtisanDomain: IArtisanDomain {
    
    private IArtisanData _artisanData;

    public ArtisanDomain(IArtisanData artisanData)
    {
        _artisanData = artisanData;
    }
    public async Task<bool> RegisterArtisanAsync(Artisan data)
    {
        var existingArtisan = await _artisanData.GetByEmailAsync(data.Email);
        if(existingArtisan != null)
        {
            throw new Exception("Email already exists");
        }
        return await _artisanData.SaveAsync(data);
    }
    public async Task<Artisan> AuthenticateArtisanAsync(string email, string password)
    {
        var existingArtisan = await _artisanData.GetByEmailAsync(email);
        if (existingArtisan == null)
        {
            throw new Exception("Email does not exist.");
        }
        if (existingArtisan.Password != password)
        {
            throw new Exception("Password is incorrect.");
        }
        if (existingArtisan != null && existingArtisan.Password == password)
        {
            return existingArtisan;
        }

        return null;
    }
    public Task<bool> UpdateArtisanAsync(int id, Artisan data)
    {
        return _artisanData.UpdateAsync(id,data);
    }
    public Task<bool> DeleteArtisanAsync(int id)
    {
        return _artisanData.DeleteAsync(id);
    }
}