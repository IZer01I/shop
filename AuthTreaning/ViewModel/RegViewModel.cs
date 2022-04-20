using AuthTreaning.Command;
using AuthTreaning.Core;
using AuthTreaning.View.Windows;
using AuthTreaning.ViewModel.Entity;
using System.Windows;
using System.Windows.Input;

namespace AuthTreaning.ViewModel
{
    public class RegViewModel : BaseViewModel
    {
        private string _login;
        private string _password;
        private string _userName;
        private string _mail;

        DbManager db = new DbManager();

        public string Login { get => _login; set => SetProperty(ref _login, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public string UserName { get => _userName; set => SetProperty(ref _userName, value); }
        public string Mail { get => _mail; set => SetProperty(ref _mail, value); }

        public ICommand RegisterUserCommand { get; private set; }

        public RegViewModel()
        {
            RegisterUserCommand = new RelayCommand(RegisterUser);
        }

        public RegViewModel(User user) : this()
        {
            _login = user.Login.ToString();
            _password = user.Password.ToString();
            _mail = user.Mail.ToString();
            _userName = user.UserName.ToString();
        }

        private async void RegisterUser(object obj)
        {
            User user = new User()
            {
                Login = Login,
                Password = Password,
                Mail = Mail,
                UserName = UserName,
                CountryID = 1,
                RoleID = 1
            };

            if (await db.PostUser(user))
            {
                MessageBox.Show("Регистрация прошла успешно!");

                StoreWindow store = new StoreWindow();
                store.Show();
                foreach (Window item in Application.Current.Windows)
                {
                    if (item is RegWindow)
                    {
                        item.Close();
                    }
                }
                return;
            }
            else MessageBox.Show("Такой пользователь уже существует!");
        }
    }
}
