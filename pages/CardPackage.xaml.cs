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
    /// Логика взаимодействия для CardPackage.xaml
    /// </summary>
    public partial class CardPackage : Page
    {
        public CardPackage(List<Package> packages)
        {
            InitializeComponent();

            cbClient.DisplayMemberPath = "phone";
            cbClient.SelectedValuePath = "clientID";
            cbClient.ItemsSource = Db.model.Client.ToList();

            cbStatus.DisplayMemberPath = "name";
            cbStatus.SelectedValuePath = "statusID";
            cbStatus.ItemsSource = Db.model.Status.ToList();

            cbUser.DisplayMemberPath = "login";
            cbUser.SelectedValuePath = "userID";
            cbUser.ItemsSource = Db.model.User.ToList();

            lwPackage.ItemsSource = packages;
        }

        private void bGoCard_Click(object sender, RoutedEventArgs e)
        {
            foreach (Package package in lwPackage.Items)
            {
                Receipt receipt = new Receipt()
                {
                    Client = cbClient.SelectedItem as Client,
                    packageID = package.packageID,
                    date = DateTime.Now,
                    Status = cbStatus.SelectedItem as Status,
                    User = cbUser.SelectedItem as User,
                };
                Db.model.Receipt.Add(receipt);
                Db.model.SaveChanges();
            }
            MessageBox.Show("Успешная фиксация заказа, он уже в обработке\nОжидайте звонка", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.GoBack();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
