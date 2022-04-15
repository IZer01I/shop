using OnlineGameStore.Core;
using OnlineGameStore.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineGameStore.ViewModel
{
    class AuthViewModel : BaseViewModel
    {
        private readonly AuthHelper authHelper;

        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public AuthViewModel()
        {
            authHelper = new AuthHelper();
        }

        public async void Authorize()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Не все поля заполнены!");
                    return;
                }

                if (await authHelper.AuthHelp(Login, Password))
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
