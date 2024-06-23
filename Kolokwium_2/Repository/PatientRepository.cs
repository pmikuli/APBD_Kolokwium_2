using Kolokwium_2.Interfaces;
using Kolokwium_2.Models;
using Kolokwium_2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly Context _context;
    
    public PatientRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<PatientDTO> getPatient(int idPatient)
    {
        var patient = await _context.Patients
            .Where(e => e.IdPatient == idPatient)
            .Include(e => e.Visits)
            .ThenInclude(e => e.Doctor)
            .FirstOrDefaultAsync();

        if (patient == null)
        {
            throw new Exception("Patient mot found");
        }

        double totalSpent = patient.Visits.Sum(v => v.Price);

        var visits = new List<VisitDTO>();
        foreach (var v in patient.Visits)
        {
            visits.Add(new VisitDTO()
            {
                Date = v.Date,
                Doctor = v.Doctor.FirstName + " " + v.Doctor.LastName,
                IdVisit = v.IdDoctor,
                Price = v.Price + " zł"
            });
        }

        return new PatientDTO()
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            TotalAmountMoneySpent = totalSpent + " zł",
            NumberOfVisits = patient.Visits.Count,
            Visits = visits
        };
    }
}