using System.ComponentModel.DataAnnotations;

namespace Kolokwium_2.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public double PriceForVisit { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; }
    public virtual ICollection<Visit> Visits { get; set; }
    
}