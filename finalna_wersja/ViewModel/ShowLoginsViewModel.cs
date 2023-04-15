using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace finalna_wersja.ViewModel
{
    public class ShowLoginsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }




        ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> ListOfLogins
        {
            get
            {
                users.Clear();
                using (var context = new ManagementModelEntities())
                {
                    foreach (var _user in context.User)
                    {
                        users.Add(_user);
                    }
                    return users;
                }
            }
            set
            {
                MessageBox.Show("set.");
            }
        }


    }
}
