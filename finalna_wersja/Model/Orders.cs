using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalna_wersja.Model
{
    public class Orders
        : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        private int id;
        private int quantity;
        private decimal uPrice;
        private decimal totPrice;


        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        public decimal UPrice
        {
            get { return uPrice; }
            set
            {
                if (uPrice != value)
                {
                    uPrice = value;
                    OnPropertyChanged(nameof(UPrice));
                }
            }
        }

        public decimal TotPrice
        {
            get
            {
                return totPrice;
            }
            set
            {
                if(totPrice != value)
                {
                    totPrice = value;
                    OnPropertyChanged(nameof(TotPrice));
                }
            }
        }

    }
}
