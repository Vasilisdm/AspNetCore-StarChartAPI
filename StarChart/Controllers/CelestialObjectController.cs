using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;
using StarChart.Models;

namespace StarChart.Controllers
{
    [ApiController]
    [Route("")]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id: int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.Find(id);

            if (celestialObject == null)
            {
                return NotFound();
            }

            celestialObject.Satellites = new List<CelestialObject>();

            return Ok(celestialObject);
        }

        //[HttpGet("{name}")]
        //public IActionResult GetByName(string name)
        //{
        //    var celestialObject = _context.CelestialObjects.Find(name);

        //    if (celestialObject == null)
        //    {
        //        return NotFound();
        //    }


        //}
    }
}
