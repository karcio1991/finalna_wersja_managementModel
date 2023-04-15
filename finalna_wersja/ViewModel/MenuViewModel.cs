using finalna_wersja.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace finalna_wersja.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public MenuViewModel()
        {
            btnUsers = new MyCommand(clickUsers_method);
        }

        private void clickUsers_method()
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
        }

        private MyCommand btnUsers;
        public MyCommand BtnUsers
        {
            get
            {
                return btnUsers;
            }
            set
            {
                btnUsers = value;
                OnPropertyChanged(nameof(BtnUsers));
            }
        }
    }
}
