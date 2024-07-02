using Fullstack.Domain.Entities;
using System.Collections.Generic;  
using System.Threading.Tasks; 

namespace Fullstack.Domain.Interfaces
{
    public interface IDataRepository  
    {  
        Task<IEnumerable<DataModel>> GetAllAsync();  
        Task<DataModel> GetByIdAsync(int id);  
        Task AddAsync(DataModel data);  
        Task UpdateAsync(DataModel data);  
        Task DeleteAsync(int id);  
    }
    
};

