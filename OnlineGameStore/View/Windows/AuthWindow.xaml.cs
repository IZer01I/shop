using OnlineGameStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineGameStore.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        private AuthViewModel AuthViewModel;

        public AuthWindow()
        {
            InitializeComponent();

            DataContext = AuthViewModel = new AuthViewModel();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow reg = new MainWindow();

            reg.Show();

            foreach (Window item in Application.Current.Windows)
            {
                if (item is AuthWindow)
                {
                    item.Close();
                }
            }
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            AuthViewModel.Authorize();
        }
    }
}
