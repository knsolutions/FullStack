using Fullstack.Domain.Entities;  
using Fullstack.Domain.Interfaces;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks; 

namespace Fullstack.Infrastructure;

public class DataRepository : IDataRepository  
{  
    private static List<DataModel> dataStore = new List<DataModel>();  

    public async Task<IEnumerable<DataModel>> GetAllAsync()  
    {  
        return await Task.FromResult(dataStore);  
    }  

    public async Task<DataModel> GetByIdAsync(int id)  
    {  
        var data = dataStore.FirstOrDefault(d => d.Id == id);
        if (data == null)
        {
            throw new KeyNotFoundException($"No DataModel found with ID {id}.");
        } 
        return await Task.FromResult(data);  
    }  

    public async Task AddAsync(DataModel data)  
    {  
        data.Id = dataStore.Count > 0 ? dataStore.Max(d => d.Id) + 1 : 1;  
        dataStore.Add(data);  
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(DataModel data)  
    {  
        var existingData = dataStore.FirstOrDefault(d => d.Id == data.Id);  
        if (existingData == null)  
        {  
            throw new KeyNotFoundException($"No DataModel found with ID {data.Id}.");
        }  
        existingData.Key = data.Key;  
        existingData.Value = data.Value;  
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)  
    {  
        var data = dataStore.FirstOrDefault(d => d.Id == id);  
        if (data == null)  
        {  
            throw new KeyNotFoundException($"No DataModel found with ID {id}.");
        }  
        dataStore.Remove(data);  
        await Task.CompletedTask;
    }
}
