using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.VisualBasic.CompilerServices;

namespace APBD_Test2.App.DTO;

public class PostRecordDto
{
    [Required]
    public int LanguageId { get; set; }
    
    [Required]
    public int StudentId { get; set; }
    
    [Required]
    public int TaskId { get; set; }
    
    [Required]
    public BigInteger ExecutionTime { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-YYYY hh:mm:ss}")]
    [Required]
    public DateTime Created { get; set; }
}