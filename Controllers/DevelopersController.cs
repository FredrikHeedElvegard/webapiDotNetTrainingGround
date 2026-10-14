using webapiDotNetTrainingGround.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace webapiDotNetTrainingGround.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DevelopersController : ControllerBase
{
    List<Developer> _db;

    public DevelopersController()
    {
        _db = new() { new Developer() { Id = 0, Name = "Gustaf", Email = "Gustaf@HUUHUH.com" } };
    }

    [HttpGet]
    [EndpointName("GetAllDevelopers")]
    public List<Developer> GetAllDevelopers()
    {
        return _db;
    }

    [HttpGet("{id}")]
    public Developer? GetDeveloperByID(int id)
    {
        return _db.Find(x => x.Id == id);
    }


    [HttpPost]
    public IActionResult CreateDeveloper(Developer developerToAdd)
    {
        var nextId = _db.Count;
        developerToAdd.Id = nextId;
        _db.Add(developerToAdd);

        return CreatedAtAction(nameof(GetDeveloperByID), new { id= nextId}, developerToAdd);
    }

}