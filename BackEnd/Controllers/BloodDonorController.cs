using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppContext = WebApplicationAnaHon.Data.AppDbContext;
using AnahoneAPI.Models;
namespace WebApplicationAnaHon.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BloodDonorController : ControllerBase
{
    private readonly AppContext _context; 

    public BloodDonorController(AppContext context)
    {
        _context = context;
    }


    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<BloodDonor>>> GetBloodDonors()
    {
        return await _context.Donors.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BloodDonor>> GetBloodDonor(int id)
    {
        var bloodDonor = await _context.Donors.FindAsync(id);

        if (bloodDonor == null)
        {
            return NotFound();
        }

        return bloodDonor;
    }


    // POST: api/BloodDonors
        [HttpPost("Add")]
        public async Task<ActionResult<BloodDonor>> CreateBloodDonor(
        string firstName, string lastName, string gender, DateTime dateOfBirth,
        string bloodType, DateTime? lastDonationDate, string phoneNumber, string email,
        string medicalConditions) 
        {
        var bloodDonor = new BloodDonor
        {
            FirstName = firstName,
            LastName = lastName,
            Gender = gender,
            DateOfBirth = dateOfBirth,
            BloodType = bloodType,
            LastDonationDate = lastDonationDate,
            PhoneNumber = phoneNumber,
            Email = email,
            MedicalConditions = medicalConditions
        };

        _context.Donors.Add(bloodDonor);
        await _context.SaveChangesAsync();

       // return CreatedAtRoute("GetBloodDonor", new { id = bloodDonor.DonorID }, bloodDonor);
        return Ok(bloodDonor);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchDonors(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("Search keyword is required.");
        }

        var donors = await _context.Donors
            .Where(d =>
                d.FirstName.Contains(keyword) ||
                d.LastName.Contains(keyword) ||
                d.Gender.Contains(keyword) ||
                d.BloodType.Contains(keyword) ||
                d.Email.Contains(keyword))
            .ToListAsync();

        if (donors == null || donors.Count == 0)
        {
            return NotFound("No matching donors found.");
        }

        return Ok(donors);
    }








    private bool BloodDonorExists(int id)
    {
        return _context.Donors.Any(e => e.DonorID == id);
    }

}
