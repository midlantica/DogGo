using DogGo.Controllers;
using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class DogFormViewModel
    {
        public Dog Dog { get; set; }
        //public List<Dog> Dogs { get; set; }
        public List<Owner> Owners { get; set; }
        //public List<Neighborhood> Neighborhoods { get; set; }
    }
}