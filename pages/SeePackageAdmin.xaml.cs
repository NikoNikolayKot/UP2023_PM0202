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
using System.Xml.Linq;
using UP2023_PM0202.classes;

using UP2023_PM0202.db;

namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для SeePackageAdmin.xaml
    /// </summary>
    public partial class SeePackageAdmin : Page
    {
        public SeePackageAdmin()
        {
            InitializeComponent();

            cbSort.SelectedIndex = 0;

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
            catch(Exception ex)
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

        private void bGoEdit_Click(object sender, RoutedEventArgs e)
        {
            Package package = new Package();
            package = lwPackage.SelectedItem as Package;
            NavigationService.Navigate(new Edit(package));
        }

        private void bGoAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add());
        }

        private void bGoDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Package package = new Package();                                                                
                package = lwPackage.SelectedItem as Package;                                                                     
                if (package != null)                                                                            
                {                                                                                               
                    Db.model.Package.Remove(package);                                                                                      
                    MessageBox.Show("Удалено", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information); 
                    Db.model.SaveChanges();                                                                     
                }                                                                                               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + "", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
