using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrigoPets.Models
{
    public class Pet
    {
        public int PetId;

        public string Type;

        public string Name;

        public string Breed;

        public string Description;

        public string Note;

        public string Size;

        public string Sex;

        public int Age;

        public bool UpToDateVaccines;

        public bool ToBeAdopted;

        public bool Castrated;

        public DateTime DateOfArrival;

        public DateTime NextVaccine;
    }
}
