using System.ComponentModel.DataAnnotations;

namespace Kolokwium_2.Models;

public class Schedule
{
    [Key]
    public int IdSchedule { get; set; }
    public int IdDoctor { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public Doctor? Doctor { get; set; }
}