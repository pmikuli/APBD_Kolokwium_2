using Kolokwium_2.Interfaces;
using Kolokwium_2.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_2.Controllers;

[ApiController]
[Route("/api/visit")]
public class VisitController : ControllerBase
{
    public readonly IVisitRepository _visitRepository;
    
    public VisitController(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddVisit([FromBody] AddVisitDTO dto)
    {
        try
        {
            var id = await _visitRepository.AddVisit(dto);
            return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}