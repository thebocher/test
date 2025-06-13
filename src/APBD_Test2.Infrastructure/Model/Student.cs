using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Test2.Infrastructure.Model;

public class Student
{
    [Required]
    [Length(0, 100)]
    public string FirstName { get; set; }
    
    [Required]
    [Length(0, 100)]
    public string LastName { get; set; }
    
    [Required]
    [Length(0, 250)]
    public string Email { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public virtual ICollection<Record> Records { get; set; }
}