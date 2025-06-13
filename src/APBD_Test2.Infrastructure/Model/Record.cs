using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace APBD_Test2.Infrastructure.Model;

public class Record
{
    public int LanguageId { get; set; }
    
    [ForeignKey("LanguageId")]
    [NotMapped]
    public Language Language { get; set; }
    
    public int TaskId { get; set; }
    
    [ForeignKey("TaskId")]
    [NotMapped]
    public Task Task { get; set; }
    
    public int StudentId { get; set; }
    
    [ForeignKey("StudentId")]
    [NotMapped]
    public Student Student { get; set; }

    [Column(TypeName = "bigint")]
    public BigInteger ExecutionTime { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}