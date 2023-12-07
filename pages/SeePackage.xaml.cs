using System;
using System.Collections.Generic;
using System.IO;
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
using UP2023_PM0202.classes;
using UP2023_PM0202.db;

namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для SeePackage.xaml
    /// </summary>
    public partial class SeePackage : Page
    {
        List<Package> packages = new List<Package>();
        public SeePackage()
        {
            InitializeComponent();

            cbFilt.DisplayMemberPath = "name";
            cbFilt.SelectedValuePath = "typePackageID";
            cbFilt.ItemsSource = Db.model.TypePackage.ToList();

            lwPackage.ItemsSource = Db.model.Package.ToList();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int selectionIndex = cbSort.SelectedIndex;
                switch (selectionIndex)
                {
                    case 0:
                        lwPackage.ItemsSource = Db.model.Package.ToList();
                        break;
                    case 1:
                        lwPackage.ItemsSource = Db.model.Package.OrderBy(x => x.TypePackage.typePackageID).ToList();
                        break;
                    case 2:
                        lwPackage.ItemsSource = Db.model.Package.OrderByDescending(x => x.TypePackage.typePackageID).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedValue = cbFilt.SelectedValue;
                int selectedValueInt = int.Parse(selectedValue + "");
                lwPackage.ItemsSource = Db.model.Package.Where(x => x.typePackageID == selectedValueInt).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                lwPackage.ItemsSource = Db.model.Package.Where(x => x.name.Contains(tbSearch.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lwPackage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Package package = new Package();
            package = lwPackage.SelectedItem as Package;
            packages.Add(package);
        }

        private void bCard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CardPackage(packages));
        }
    }
}
