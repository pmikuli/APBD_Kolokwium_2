using System.ComponentModel.DataAnnotations;

namespace Kolokwium_2.Models;

public class Visit
{
    [Key]
    public int IdVisit { get; set; }
    public DateTime Date { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public double Price { get; set; }
    
    public Patient? Patient { get; set; }
    public Doctor? Doctor { get; set; }
}