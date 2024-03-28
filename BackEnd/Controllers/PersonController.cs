using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAnaHon.Data;
using WebApplicationAnaHon.Data.Models;

namespace WebApplicationAnaHon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;
        
      
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllPersons()
        {
            var person = await _db.Persons.ToListAsync();
            return Ok(person);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _db.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson(string firstname, string lastname, int age , string gender, DateTime lastseendate , string location, string description, string casedetails, string clothingdescription, int heightcm , int weightkg , string haircolur , string eyecolor, string photopath, string contact, string casestatus)
        {
            MissingPersons p = new() { FirstName = firstname, LastName = lastname, Age = age, Gender = gender , LastSeenDate =lastseendate, Location = location, Description = description, CaseDetails=casedetails,ClothingDescription= clothingdescription, HeightCM= heightcm, WeightKG=weightkg, HairColor= haircolur, EyeColor=eyecolor, PhotoPath= photopath, Contact= contact, CaseStatus= casestatus };
            await _db.Persons.AddAsync(p);
            _db.SaveChanges();
            return Ok(p);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchPersons(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("Search keyword is required.");
            }

            var persons = await _db.Persons
                .Where(p =>
                    p.FirstName.Contains(keyword) ||
                    p.LastName.Contains(keyword) ||
                    p.Age.ToString().Contains(keyword) ||
                    p.Gender.Contains(keyword) ||
                    p.LastSeenDate.ToString().Contains(keyword) ||
                    p.Location.Contains(keyword) ||
                    p.Description.Contains(keyword) ||
                    p.CaseDetails.Contains(keyword) ||
                    p.ClothingDescription.Contains(keyword) ||
                    p.HeightCM.ToString().Contains(keyword) ||
                    p.WeightKG.ToString().Contains(keyword) ||
                    p.HairColor.Contains(keyword) ||
                    p.EyeColor.Contains(keyword) ||
                    p.PhotoPath.Contains(keyword) ||
                    p.Contact.Contains(keyword) ||
                    p.CaseStatus.Contains(keyword))
                .ToListAsync();

            if (persons == null || persons.Count == 0)
            {
                return NotFound("No matching persons found.");
            }

            return Ok(persons);
        }


    }
}
