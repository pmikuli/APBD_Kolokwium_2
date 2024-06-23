using Kolokwium_2.Interfaces;
using Kolokwium_2.Models;
using Kolokwium_2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Repository;

public class VisitRepository : IVisitRepository
{
    private readonly Context _context;
    
    public VisitRepository(Context context)
    {
        _context = context;
    }
    
    public async Task AddVisit(AddVisitDTO dto)
    {
        // _context.Visits.Add().
        var doctor = await _context.Doctors
            .Where(e => e.IdDoctor == dto.IdDoctor)
            .Include(e => e.Schedules)
            .FirstOrDefaultAsync(e => e.IdDoctor == dto.IdDoctor);

        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }

        var patient = await _context.Patients
            .Where(e => e.IdPatient == dto.IdPatient)
            .Include(e => e.Visits)
            .FirstOrDefaultAsync(e => e.IdPatient == dto.IdPatient);

        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        if (patient.Visits.Any(v => v.Date > DateTime.Now))
        {
            throw new Exception("Patient already has planned visits");
        }

        if (doctor.Schedules.Any(e => e.DateFrom > dto.Date && e.DateTo < dto.Date))
        {
            throw new Exception("The doctor is unavailable during proposed visit time");
        }

        Visit visit = new Visit();
        visit.IdPatient = patient.IdPatient;
        visit.IdDoctor = doctor.IdDoctor;
        visit.Date = dto.Date;

        if (patient.Visits.Count > 10)
            visit.Price = doctor.PriceForVisit * 0.1;
        else
            visit.Price = doctor.PriceForVisit;

        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();
    }
}