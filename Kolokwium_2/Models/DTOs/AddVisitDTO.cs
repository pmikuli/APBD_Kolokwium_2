namespace Kolokwium_2.Models.DTOs;

public class AddVisitDTO
{
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }
}