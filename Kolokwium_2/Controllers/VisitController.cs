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
    public async Task<IActionResult> addVisit([FromBody] AddVisitDTO dto)
    {
        await _visitRepository.AddVisit(dto);
        return Ok();
    }
}