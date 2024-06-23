namespace Kolokwium_2.Models.DTOs;

public class PatientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string TotalAmountMoneySpent { get; set; }
    public int NumberOfVisits { get; set; }
    public List<VisitDTO> Visits { get; set; }
}