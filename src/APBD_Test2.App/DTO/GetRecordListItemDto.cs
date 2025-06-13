using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.VisualBasic;

namespace APBD_Test2.App.DTO;

public class GetRecordListItemDto
{
    public int Id { get; set; }
    
    public GetRecordListItemLanguageDto Language { get; set; }
    
    public GetRecordListItemTaskDto Task { get; set; }
    
    public GetRecordListItemStudentDto Student { get; set; }
    
    public BigInteger ExecutionTime { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-YYYY hh:mm:ss}")]
    public DateTime Created;
}