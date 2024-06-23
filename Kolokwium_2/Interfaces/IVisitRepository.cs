using Kolokwium_2.Models.DTOs;

namespace Kolokwium_2.Interfaces;

public interface IVisitRepository
{
    Task AddVisit(AddVisitDTO dto);
}