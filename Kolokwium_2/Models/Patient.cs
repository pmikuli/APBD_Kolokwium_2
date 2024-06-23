using System.ComponentModel.DataAnnotations;

namespace Kolokwium_2.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public virtual ICollection<Visit> Visits { get; set; }
}