using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbrigoPets.Models;

namespace AbrigoPets.ViewModels
{
    public class PetViewModel : INotifyPropertyChanged
    {
        public PetViewModel(Pet pet)
        {
            this.Pet = pet;
        }

        public Pet Pet { get; set; }
        
        public string Type
        {
            get
            {
                return this.Pet.Type;
            }
            set
            {
                this.Pet.Type = value;
                OnPropertyChanged("NameView");
            }
        }

        public string Name {
            get
            {
                return Pet.Name;
            }
            set
            {
                Pet.Name = value;
                OnPropertyChanged("NameView");
            }
        }
        
        public string Breed { get => this.Pet.Breed;
            set => this.Pet.Breed = value;
        }
        
        public string Description { get => this.Pet.Description;
            set => this.Pet.Description = value;
        }
        
        public string Note { get => this.Pet.Note;
            set => this.Pet.Note = value;
        }

        public string Size { get => this.Pet.Size;
            set => this.Pet.Size = value;
        }

        public string Sex { get => this.Pet.Sex;
            set => this.Pet.Sex = value;
        }

        public int Age { get => this.Pet.Age;
            set => this.Pet.Age = value;
        }

        public bool UpToDateVaccines { get => this.Pet.UpToDateVaccines;
            set => this.Pet.UpToDateVaccines = value;
        }

        public bool ToBeAdopted { get => this.Pet.ToBeAdopted;
            set => this.Pet.ToBeAdopted = value;
        }

        public bool Castrated { get => this.Pet.Castrated;
            set => this.Pet.Castrated = value;
        }

        public DateTime DateOfArrival { get => this.Pet.DateOfArrival;
            set => this.Pet.DateOfArrival = value;
        }

        public DateTime NextVaccine { get => this.Pet.NextVaccine;
            set => this.Pet.NextVaccine = value;
        }

        public string NameView => this.Pet.Name + " - " + this.Pet.Type;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
