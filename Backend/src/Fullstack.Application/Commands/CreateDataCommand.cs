using MediatR;  


namespace Fullstack.Application.Commands;

public class CreateDataCommand : IRequest<int>  
{  
    public string Key { get; set; }  
    public string Value { get; set; }  
    public string CreatedBy { get; set; }

    public CreateDataCommand(string key, string value, string createdBy)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Value = value ?? throw new ArgumentNullException(nameof(value));
        CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
    }
}