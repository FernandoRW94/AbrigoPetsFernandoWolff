using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrigoPets.ViewModels
{
    public class ManagementViewModel : INotifyPropertyChanged
    {
        private string shelterName;
        public string ShelterName
        {
            get
            {
                return shelterName;
            }
            set
            {
                shelterName = value;
                OnPropertyChanged("ShelterName");
            }
        }


        private decimal shelterMoney;
        public decimal ShelterMoney {
            get{ return shelterMoney; }
            set
            {
                shelterMoney = value;
                OnPropertyChanged("ShelterMoneyFormated");
                OnPropertyChanged("ShelterMoney");
            }
        }


        private decimal lastRevenue;
        public decimal LastRevenue
        {
            get
            {
                return lastRevenue;
            }
            set
            {
                lastRevenue = value;
                OnPropertyChanged("LastRevenue");
                OnPropertyChanged("LastRevenueFormated");
            }
        }


        private decimal lastExpense;
        public decimal LastExpense
        {
            get
            {
                return lastExpense;
            }
            set
            {
                lastExpense = value;
                OnPropertyChanged("LastExpense");
                OnPropertyChanged("LastExpenseFormated");
            }
        }


        private decimal totalFood;
        public decimal TotalFood {
            get { return totalFood; }
            set
            {
                totalFood = value;
                OnPropertyChanged("TotalFood");
                OnPropertyChanged("TotalFoodFormated");
            }
        }


        private int totalAnimals;
        public int TotalAnimals {
            get { return totalAnimals; }
            set
            {
                totalAnimals = value;
                OnPropertyChanged("TotalAnimals");
            }
        }


        private int totalCats;
        public int TotalCats {
            get { return totalCats; }
            set
            {
                totalCats = value;
                OnPropertyChanged("TotalCats");
            }
        }


        private int totalDogs;
        public int TotalDogs
        {
            get { return totalDogs; }
            set
            {
                totalDogs = value;
                OnPropertyChanged("TotalDogs");
            }
        }


        public string ShelterMoneyFormated
        {
            get { return ShelterMoney.ToString("C", CultureInfo.CurrentCulture); }
        }

        public string LastRevenueFormated
        {
            get
            {
                return LastRevenue.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public string TotalFoodFormated
        {
            get { return string.Format("{0}kg", TotalFood); }
        }

        public string LastExpenseFormated
        {
            get
            {
                return LastExpense.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private decimal foodEntry;
        public decimal FoodEntry
        {
            get { return this.foodEntry; }
            set
            {
                this.foodEntry = value;
                OnPropertyChanged("FoodEntry");
            }
        }

        private decimal foodComsumption;
        public decimal FoodConsumption {
            get { return this.foodComsumption; }
            set
            {
                this.foodComsumption = value;
                OnPropertyChanged("FoodConsumption");
            }
        }

        private decimal revenue;
        public decimal Revenue {
            get { return this.revenue; }
            set
            {
                this.revenue = value;
                OnPropertyChanged("Revenue");
            }
        }

        private decimal expense;
        public decimal Expense {
            get { return this.expense; }
            set
            {
                this.expense = value;
                OnPropertyChanged("Expense");
            }
        }
    }
}
