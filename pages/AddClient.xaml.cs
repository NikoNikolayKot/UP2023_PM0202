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
using UP2023_PM0202.classes;
using UP2023_PM0202.db;

namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Client client = new db.Client()
                {
                    lastName = tbLastName.Text,
                    name = tbName.Text,
                    phone = tbPhone.Text,
                };

                Db.model.Client.Add(client);
                Db.model.SaveChanges();

                MessageBox.Show("Клиент: " + tbLastName.Text + " " + tbName.Text + ". Добавлен успешно", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
