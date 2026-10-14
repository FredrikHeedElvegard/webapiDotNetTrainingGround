using webapiDotNetTrainingGround.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace webapiDotNetTrainingGround.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DevelopersController : ControllerBase
{
    Db _db;

    public DevelopersController(Db db)
    {
        _db = db;
    }

    [HttpGet]
    [EndpointName("GetAllDevelopers")]
    public List<Developer> GetAllDevelopers()
    {
        return _db.Developers;
    }

    [HttpGet("{id}")]
    public Developer? GetDeveloperByID(int id)
    {
        return _db.Developers.Find(x => x.Id == id);
    }


    [HttpPost]
    public IActionResult CreateDeveloper(Developer developerToAdd)
    {
        var nextId = _db.Developers.Count;
        developerToAdd.Id = nextId;
        _db.Developers.Add(developerToAdd);

        return CreatedAtAction(nameof(GetDeveloperByID), new { id = nextId }, developerToAdd);
    }

}

