using finalna_wersja.Model;
using finalna_wersja.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace finalna_wersja.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {

        public UserViewModel()
        {
            loginClick = new MyCommand(clickLogin_method);
            btnZatwierdz = new MyCommand(clickZatwierdz_method);
            btnCreateAccount = new MyCommand(clickCreateAccount_method);
            btnPokazBazeDanych = new MyCommand(clickPokazBazeDanych_method);
        }

        private void clickPokazBazeDanych_method()
        {
            ShowLogins showLogins = new ShowLogins();
            showLogins.Show();
        }

        private void clickCreateAccount_method()
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        private void clickZatwierdz_method()
        {
            User user = new User();
            user.UserName = TbUserName;
            user.Password = TbPassword;
            user.FullName = TbFullName;
            user.PhoneNumber = TbPhone;

            using (var context = new ManagementModelEntities())
            {
                if (context.User.ToList().Any(x => x.UserName == user.UserName))
                {
                    MessageBox.Show("Choose other UserName.");
                    return;

                }

                context.User.Add(user);
                context.SaveChanges();
                MessageBox.Show("Done.");
            }
        }

        private void clickLogin_method()
        {
            using (var context = new ManagementModelEntities())
            {
                var correctLogin = context.User.FirstOrDefault(x => x.UserName == TbUserName && x.Password == TbPassword);
                if (correctLogin != null)
                {
                   MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();
                }
            }
        }

        private MyCommand loginClick;
        public MyCommand LoginClick
        {
            get
            {

                return loginClick;
            }
            set
            {
                if (loginClick != null)
                {
                    loginClick = value;
                    OnPropertyChanged(nameof(LoginClick));
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
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

        private string tbLogin;
        public string TbLogin
        {
            get
            {
                return tbLogin;
            }
            set
            {
                tbLogin = value;
                OnPropertyChanged(nameof(TbLogin));
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

        private string tbPhone;
        public string TbPhone
        {
            get
            {
                return tbPhone;
            }
            set
            {
                tbPhone = value;
                OnPropertyChanged(nameof(TbPhone));
            }
        }


        private MyCommand btnZatwierdz;
        public MyCommand BtnZatwierdz
        {
            get
            {
                return btnZatwierdz;
            }
            set
            {
                btnZatwierdz = value;
                OnPropertyChanged(nameof(BtnZatwierdz));
            }
        }

        private MyCommand btnCreateAccount;
        public MyCommand BtnCreateAccount
        {
            get
            {
                return btnCreateAccount;
            }
            set
            {
                btnCreateAccount = value;
                OnPropertyChanged(nameof(BtnCreateAccount));
            }
        }
        private MyCommand btnPokazBazeDanych;
        public MyCommand BtnPokazBazeDanych
        {
            get
            {
                return btnPokazBazeDanych;
            }
            set
            {
                btnPokazBazeDanych = value;
                OnPropertyChanged(nameof(BtnPokazBazeDanych));
            }
        }

    }
}
