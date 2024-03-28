    using System.ComponentModel.DataAnnotations;

    namespace AnahoneAPI.Models;
    public class BloodDonor
    {
        [Key]
        public int DonorID { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
         [MaxLength(50)]
         [Required]
        public string LastName { get; set; }   
        [Required]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MedicalConditions { get; set; }
    }