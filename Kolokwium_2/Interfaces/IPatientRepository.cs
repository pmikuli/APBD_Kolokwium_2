using Kolokwium_2.Models;
using Kolokwium_2.Models.DTOs;

namespace Kolokwium_2.Interfaces;

public interface IPatientRepository
{
    Task<PatientDTO> getPatient(int idPatient);
}