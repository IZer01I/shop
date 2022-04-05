using OnlineGameStore.Core;
using OnlineGameStore.Entity;
using OnlineGameStore.View.Windows;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;

namespace OnlineGameStore.ViewModel
{
    public class RegViewModel : BaseViewModel
    {
        private int _code;

        private string _login;
        private string _password;
        private string _mail;
        private string _userName;
        private string _codeConf;
        private Country _selectedCountry;
        private ObservableCollection<Country> _countries;

        private RegistryHelper registryHelper;

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

        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string CodeConf
        {
            get => _codeConf;
            set
            {
                _codeConf = value;
                OnPropertyChanged(nameof(CodeConf));
            }
        }

        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        public ObservableCollection<Country> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged(nameof(Countries));
            }
        }

        public RegViewModel()
        {
            registryHelper = new RegistryHelper();

            _countries = new ObservableCollection<Country>();

            using (var context = new OGSEntities())
            {
                foreach (var country in context.Country)
                    _countries.Add(country);
            }
        }

        public RegViewModel(User user, Country country) : this()
        {
            _login = user.Login.ToString();
            _password = user.Password.ToString();
            _mail = user.Mail.ToString();
            _userName = user.UserName.ToString();
            _selectedCountry = country;
        }

        public async void Registry(int code)
        {
            if (code.ToString() == CodeConf)
            {
                User user = new User()
                {
                    Login = Login.GetHashCode(),
                    Password = Password.GetHashCode(),
                    Mail = Mail,
                    UserName = UserName,
                    CountryID = _selectedCountry.ID,
                    RoleID = 1
                };

                if (await registryHelper.PostUser(user))
                {
                    MessageBox.Show("Регистрация прошла успешно!");

                    StoreWindow main = new StoreWindow();
                    main.Show();
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item is MainWindow)
                        {
                            item.Close();
                        }
                    }


                    return;
                }
                MessageBox.Show("Такой пользователь уже существует!");
            }
        }

        public async void SendCode()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(UserName))
                {
                    MessageBox.Show("Не все поля заполнены!");
                    return;
                }

                Random rand = new Random();
                _code = rand.Next(1000, 9999);

                SmtpClient _smtp = new SmtpClient("smtp.mail.ru", 25)
                {
                    Credentials = new NetworkCredential("edik_yampolski@mail.ru", "ugr25G4W6EJXMdk038qz"),
                    EnableSsl = true
                };
                MailMessage _mail = new MailMessage
                {
                    From = new MailAddress("edik_yampolski@mail.ru")
                };
                _mail.To.Add(new MailAddress(Mail));
                _mail.SubjectEncoding = Encoding.UTF8;
                _mail.BodyEncoding = Encoding.UTF8;
                _mail.Subject = "IZer0I.Shop";
                _mail.Body = "Код подтверждения: " + _code;
                await _smtp.SendMailAsync(_mail);

                MailСonf mailСonf = new MailСonf(new User()
                {
                    Login = Login.GetHashCode(),
                    Password = Password.GetHashCode(),
                    Mail = Mail,
                    UserName = UserName,
                    RoleID = 1
                }, _selectedCountry, _code);
                mailСonf.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

//updaPPYaA91