using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(55, MinimumLength = 5)]
        public string Address { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [Required]
        public int NeighborhoodId { get; set; }

        // LOOK AT THIS
        //  Added a property to store an entire Neighborhood
        //  We wil use this to display the name of the Neighborhood instead of the NeighborhoodId
        [Required]
        [DisplayName("Neighborhood")]
        public Neighborhood Neighborhood { get; set; }
        //public List<Dog> Dogs { get; set; }
    }
}
