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
    public class ManageUsersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public ManageUsersViewModel()
        {
            btnAdd = new MyCommand(clickAdd_method);
            btnDelete = new MyCommand(clickDelete_method);
            btnHome = new MyCommand(clickHome_method);
            btnClear = new MyCommand(clickClear_method);

            tbUserName = "UserName";
            tbFullName = "FullName";
            tbPassword = "Password";
            tbPhoneNumber = "PhoneNumber";



        }

        private void clickClear_method()
        {

            TbUserName = "";
            TbFullName = "";
            TbPassword = "";
            TbPhoneNumber = "";
        }

        private void clickHome_method()
        {
            MessageBox.Show("clickHome_method");
        }

        private void clickDelete_method()
        {
            MessageBox.Show("clickDelete_method");
            User user = selectedItem as User;
            using (var context = new ManagementModelEntities())
            {
                user = context.User.FirstOrDefault(x => x.Id == user.Id);
                context.User.Remove(user);
                context.SaveChanges();
                ListOfUsers = Update_ListOfUsers();
            }
        }

        private void clickAdd_method()
        {
            MessageBox.Show("Zapis.");

            User user = new User();
            user.UserName = tbUserName;
            user.FullName = tbFullName;
            user.Password = tbPassword;
            user.PhoneNumber = tbPhoneNumber;

            using (var context = new ManagementModelEntities())
            {
                context.User.Add(user);
                context.SaveChanges();
            }

            //aktualizacja datagrid'a

            ListOfUsers = Update_ListOfUsers();

        }

        //funkcja aktualizujaca stan kontrolki datagrid!
        public ObservableCollection<User> Update_ListOfUsers()
        {
            users_datagrid.Clear();
            using (var context = new ManagementModelEntities())
            {
                foreach (var user in context.User)
                {
                    users_datagrid.Add(user);
                }
                return users_datagrid;
            }
        }


        private object selectedItem;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private MyCommand btnAdd;
        public MyCommand BtnAdd
        {
            get
            {
                return btnAdd;
            }
            set
            {
                btnAdd = value;
                OnPropertyChanged(nameof(BtnAdd));
            }
        }

        private MyCommand btnDelete;
        public MyCommand BtnDelete
        {
            get
            {
                return btnDelete;
            }
            set
            {
                btnDelete = value;
                OnPropertyChanged(nameof(BtnDelete));
            }
        }

        private MyCommand btnHome;
        public MyCommand BtnHome
        {
            get
            {
                return btnHome;
            }
            set
            {
                btnHome = value;
                OnPropertyChanged(nameof(BtnHome));
            }
        }

        private MyCommand btnClear;
        public MyCommand BtnClear
        {
            get
            {
                return btnClear;
            }
            set
            {
                btnClear = value;
                OnPropertyChanged(nameof(BtnClear));
            }
        }

        private string tbUserName;
        public string TbUserName
        {
            get
            {
                return tbUserName;
            }
            set
            {
                tbUserName = value;
                OnPropertyChanged(nameof(TbUserName));
            }
        }

        private string tbFullName;
        public string TbFullName
        {
            get
            {
                return tbFullName;
            }
            set
            {
                tbFullName = value;
                OnPropertyChanged(nameof(TbFullName));
            }
        }

        private string tbPassword;
        public string TbPassword
        {
            get
            {
                return tbPassword;
            }
            set
            {
                tbPassword = value;
                OnPropertyChanged(nameof(TbPassword));
            }
        }

        private string tbPhoneNumber;
        public string TbPhoneNumber
        {
            get
            {
                return tbPhoneNumber;
            }
            set
            {
                tbPhoneNumber = value;
                OnPropertyChanged(nameof(TbPhoneNumber));
            }
        }


        private ObservableCollection<User> users_datagrid = new ObservableCollection<User>();
        public ObservableCollection<User> ListOfUsers
        {
            get
            {
                using (var context = new ManagementModelEntities())
                {
                    foreach (var user in context.User)
                    {
                        users_datagrid.Add(user);
                    }
                    return users_datagrid;
                }
            }
            set
            {

                MessageBox.Show("SET");
            }
        }

    }
}
