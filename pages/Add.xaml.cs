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
using System.IO;


namespace UP2023_PM0202.pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();

            cbType.DisplayMemberPath = "name";
            cbType.SelectedValuePath = "typePackageID";
            cbType.ItemsSource = Db.model.TypePackage.ToList();
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Package package = new db.Package()
                {
                    TypePackage = cbType.SelectedItem as TypePackage,
                    name = tbName.Text,
                    imagePath = tbNameImg.Text,
                };

                Db.model.Package.Add(package);
                Db.model.SaveChanges();

                //
                List<db.Package> packages = Db.model.Package.ToList();
                foreach (db.Package i in packages)
                {
                    string str = i.imagePath;
                    if (str == null)
                    {
                        MyHelper(str, packages, i);
                    }
                    else if(str.Equals(""))
                    {
                        MyHelper(str, packages, i);
                    }
                }
                //

                MessageBox.Show("Добавлено", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void MyHelper(string str, List<db.Package> packages, db.Package i)
        {
            str = "0.jpg";
            //str = "F:\\УП 2023 Иванкова\\UP2023_PM0202\\img\\" + str; //Home
            str = "D:\\УП 2023 Иванкова\\UP2023_PM0202\\img\\" + str;   //Work
            byte[] bytes = File.ReadAllBytes(str);
            var obj = packages.Where(x => x.packageID == i.packageID).FirstOrDefault();
            obj.image = bytes;
            Db.model.SaveChanges();
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
