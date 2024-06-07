using _3_Data.Models;

namespace _2_Domain;

public interface IArtisanDomain{
    
    Task<bool> RegisterArtisanAsync(Artisan data);
    Task<Artisan> AuthenticateArtisanAsync(string email, string password);
    Task<bool> UpdateArtisanAsync(int id, Artisan data);
    Task<bool> DeleteArtisanAsync(int id);
    
}