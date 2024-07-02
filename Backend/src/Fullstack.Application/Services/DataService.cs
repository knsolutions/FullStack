using Fullstack.Domain.Entities;  
using Fullstack.Domain.Interfaces;  
using Fullstack.Application.Models;  
using System.Collections.Generic;  
using System.Threading.Tasks; 

namespace Fullstack.Application.Services;


public class DataService  
{  
    private readonly IDataRepository _dataRepository;  

    public DataService(IDataRepository dataRepository)  
    {  
        _dataRepository = dataRepository;  
    }  

    public async Task<IEnumerable<DataModel>> GetAllAsync()  
    {  
        return await _dataRepository.GetAllAsync();  
    }  

    public async Task<DataModel> GetByIdAsync(int id)  
    {  
        return await _dataRepository.GetByIdAsync(id);  
    }  

    public async Task AddAsync(DataModelDto dataDto, string createdBy)  
    {  
        var data = new DataModel  
        {  
            Key = dataDto.Key,  
            Value = dataDto.Value,  
            CreatedBy = createdBy  
        };  
        await _dataRepository.AddAsync(data);  
    }  

    public async Task UpdateAsync(int id, DataModelDto dataDto)  
    {  
        var data = await _dataRepository.GetByIdAsync(id);  
        if (data != null)  
        {  
            data.Key = dataDto.Key;  
            data.Value = dataDto.Value;  
            await _dataRepository.UpdateAsync(data);  
        }  
    }  

    public async Task DeleteAsync(int id)  
    {  
        await _dataRepository.DeleteAsync(id);  
    }  
} 


