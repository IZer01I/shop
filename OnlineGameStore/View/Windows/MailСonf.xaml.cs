using OnlineGameStore.Entity;
using OnlineGameStore.Model;
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
    /// Логика взаимодействия для MailСonf.xaml
    /// </summary>
    public partial class MailСonf : Window
    {
        private RegViewModel regViewModel;

        private int _code;

        public MailСonf(User user, Country country, int code)
        {
            InitializeComponent();
            DataContext = regViewModel = new RegViewModel(user, country);

            _code = code;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            regViewModel.Registry(_code);


        }
    }
}
