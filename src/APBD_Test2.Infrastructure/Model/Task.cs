using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Test2.Infrastructure.Model;

public class Task
{
    [Required]
    [Length(0, 100)]
    public string Name { get; set; }
    
    [Required]
    [Length(0, 2000)]
    public string Description { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public virtual ICollection<Record> Records { get; set; }
}