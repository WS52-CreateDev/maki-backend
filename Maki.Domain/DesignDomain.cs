using System.Data;
using System.Threading.Tasks;
using _3_Data;
using _3_Data.Models;


namespace _2_Domain;

public class DesignDomain : IDesignDomain
{
    private  IDesignData _designData;

    public DesignDomain(IDesignData designData)
    {
        _designData = designData;
    }

    public async Task<int> SaveAsync(Design data)
    {
        var design = await _designData.GetByNameAsync(data.Name);
        if (design != null)
        {
            throw new DuplicateNameException("Name already exists.");
        }

        return await _designData.SaveAsync(data);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _designData.DeleteAsync(id);
    }
}