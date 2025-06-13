using System.ComponentModel.DataAnnotations;

namespace APBD_Test2.App.DTO;

public class PostRecordWithTaskTaskDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
}