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

namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void bGoSee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeeService());
        }

        private void bGoSeePackage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeePackage());
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bGoAddClient_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddClient());
        }

        private void bGoSeeClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeeClient());
        }
    }
}
