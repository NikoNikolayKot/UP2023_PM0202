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

using UP2023_PM0202.db;
using UP2023_PM0202.classes;

namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для see.xaml
    /// </summary>
    public partial class SeeService : Page
    {
        public SeeService()
        {
            InitializeComponent();

            lwService.ItemsSource = Db.model.Service.ToList();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
