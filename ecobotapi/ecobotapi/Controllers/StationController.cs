using Microsoft.AspNetCore.Mvc;
using ecobotdb.Models;
using Microsoft.EntityFrameworkCore;
using ecobotapi.DTO;

namespace ecobotapi.Controllers;

[ApiController]
[Route("[controller]")]
public class StationController:ControllerBase
{
    public StationController(EcobotContext db)
    {
        _db = db;
    }
    private readonly EcobotContext _db;
    [HttpGet("get")]
    public IActionResult Get()
    {
        var list = _db.Coordinates
            .Include(p=>p.IdStationNavigation)
            .Select(p => new StationReadDTO()
            {
                Name = p.IdStationNavigation.Name,
                City = p.IdStationNavigation.City,
                Status = p.IdStationNavigation.Status,
                Longitude = p.Longitude,
                Latitude = p.Latitude
            }).ToList();
        return Ok(list);
    }
}