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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineGameStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private RegViewModel regViewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = regViewModel = new RegViewModel();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            regViewModel.SendCode();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            //AuthWindow authWindow = new AuthWindow();
            //authWindow.Show();
            //foreach (Window item in Application.Current.Windows)
            //{
            //    if (item is RegWindow)
            //    {
            //        item.Close();
            //    }
            //}
        }
    }
}
