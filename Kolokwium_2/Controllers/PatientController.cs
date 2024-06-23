using Kolokwium_2.Interfaces;
using Kolokwium_2.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_2.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatient([FromQuery(Name = "idPatient")] int idPatient)
    {
        try
        {
            var result = await _patientRepository.getPatient(idPatient);
            return Ok(result);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
}