namespace Fullstack.Domain.Entities;

public class DataModel  
    {  
        public int Id { get; set; }  
        public string Key { get; set; } = ""; 
        public string Value { get; set; } = "";
        public string? CreatedBy { get; set; }  
    } 
