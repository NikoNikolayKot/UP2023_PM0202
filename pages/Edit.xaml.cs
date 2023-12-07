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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public Edit(Package package)
        {
            InitializeComponent();

            try
            {
                cbType.DisplayMemberPath = "name";
                cbType.SelectedValuePath = "typePackageID";
                cbType.ItemsSource = Db.model.TypePackage.ToList();

                cbType.SelectedIndex = package.typePackageID - 1;
                tbName.Text = package.name;
                tbNameImg.Text = package.imagePath;

                Db.model.Package.Remove(package);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
                    else if (str.Equals(""))
                    {
                        MyHelper(str, packages, i);
                    }
                }
                //

                MessageBox.Show("Отредактировано", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
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
    }
}
