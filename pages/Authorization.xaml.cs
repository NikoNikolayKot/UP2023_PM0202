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
using UP2023_PM0202.pages;
using UP2023_PM0202.classes;

namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void bUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = Db.model.User.FirstOrDefault(x => x.password == tbPassword.Text && x.login == tbLogin.Text);
                if (obj != null)
                {
                    switch (obj.roleID)
                    {
                        case 1:
                            NavigationService.Navigate(new Admin());
                            break;
                        case 2:
                            NavigationService.Navigate(new Manager());
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }
    }
}
