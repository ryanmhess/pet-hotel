using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetsController : ControllerBase
  {
    private readonly ApplicationContext _context;
    public PetsController(ApplicationContext context) {
      _context = context;
    }

    // This is just a stub for GET / to prevent any weird frontend errors that 
    // occur when the route is missing in this controller
    [HttpGet]
    public IEnumerable<Pet> GetPets() {
      // return new List<Pet> ();
      return _context.Pets
        .Include(petOwner => petOwner.petOwner);
    }

    [HttpGet("{id}")]
    public ActionResult<Pet> Get(int id)
    {
      Pet pet = _context.Pets.Find(id);
      return pet;
    }

    //  POST /api/pets
    [HttpPost]
    public IActionResult Create(Pet pet) 
    {
      _context.Add(pet);
      _context.SaveChanges();
      return CreatedAtAction(nameof(Create), new { id = pet.id}, pet);
    }

    //  PUT
    [HttpPut("{id}")]
    public Pet Put(int id, Pet pet)
    {
      // pet.id = id;
      _context.Update(pet);
      _context.SaveChanges();
      return pet;
    }

    //  PUT checkin/checkout
    [HttpPut("{id}/checkin")]
    [HttpPut("{id}/checkout")]
    public IActionResult Put(int id)
    {
      Pet updatePet = _context.Pets.Find(id);
      DateTime now = DateTime.UtcNow;
      
      if (updatePet.checkedInAt == null) {
        updatePet.checkedInAt = now;
      }
      else {
        updatePet.checkedInAt = null;
      }
      _context.Update(updatePet);
      _context.SaveChanges();
      return Ok(updatePet);
    }

    //  DELETE /api/pets/:id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      Pet pet = _context.Pets.Find(id);
      _context.Pets.Remove(pet);
      _context.SaveChanges();
      return NoContent();
    }
  }
}