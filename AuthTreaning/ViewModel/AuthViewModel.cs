using AuthTreaning.Command;
using AuthTreaning.Core;
using AuthTreaning.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AuthTreaning.ViewModel
{
    public class AuthViewModel : BaseViewModel
    {
        private string _login;
        private string _password;

        DbManager db = new DbManager();

        public string Login { get => _login; set => SetProperty(ref _login, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public ICommand AuthUserCommand { get; private set; }

        public AuthViewModel()
        {
            AuthUserCommand = new RelayCommand(AuthUser);
        }

        private async void AuthUser(object obj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Не все поля заполнены!");
                    return;
                }

                if (await db.AuthUser(Login, Password))
                {
                    MessageBox.Show("Вход успешно выполнен!", "", MessageBoxButton.OK);
                    StoreWindow store = new StoreWindow();

                    store.Show();

                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item is AuthWindow)
                        {
                            item.Close();
                        }
                    }
                    return;
                }
                MessageBox.Show("Пользователь не найден");
            }
            catch (Exception)
            { }
        }
    }
}
