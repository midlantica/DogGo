namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int NeighborhoodId { get; set; }

        // LOOK AT THIS
        //  Added a property to store an entire Neighborhood
        //  We wil use this to display the name of the Neighborhood instead of the NeighborhoodId
        public Neighborhood Neighborhood { get; set; }
    }
}
