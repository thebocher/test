using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Test2.Infrastructure.Model;

public class Language
{
    [Required]
    [Length(0, 100)]
    public string Name { get; set; }
    
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }     
    
    public virtual ICollection<Record> Records { get; set; }
}