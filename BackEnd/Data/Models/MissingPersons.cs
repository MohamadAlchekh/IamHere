using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplicationAnaHon.Data.Models
{
  

    public class MissingPersons
    {

        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string  FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime LastSeenDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string CaseDetails { get; set; }
        public string ClothingDescription { get; set; }
        public int HeightCM { get; set; }
        public int WeightKG { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PhotoPath { get; set; }
        public string Contact { get; set; }
        public string CaseStatus { get; set; }
    }
}
