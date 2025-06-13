using System.ComponentModel.DataAnnotations;

namespace APBD_Test2.App.DTO;

public class QueryDto
{
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-YYYY hh:mm:ss}")]
    public DateTime Created { get; set; }
    
    public int LanguageId { get; set; }
    
    public int TaskId { get; set; }
    
    public string sortBy { get; set; }
}