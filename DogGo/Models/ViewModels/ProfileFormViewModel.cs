﻿using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class ProfileFormViewModel
    {
        public Owner Owner { get; set; }
        public List<Walker> Walkers { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}