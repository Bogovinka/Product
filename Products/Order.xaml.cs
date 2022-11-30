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
using System.Windows.Shapes;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        WorkBD wBD = new WorkBD();
        public Order()
        {
            InitializeComponent();
            wBD.AddSource(SupplierT, "SELECT ID, Name FROM Logins WHERE Type_acc = 4");
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            wBD.insertDB(ProductT.Text[0].ToString(), SupplierT.Text[0].ToString());
            sc1.IsChecked = false;
            sc2.IsChecked = false;
            sc3.IsChecked = false;
            sc4.IsChecked = false;
            SupplierT.Text = "";
            ProductT.Text = "";
        }

        private void sc1_Checked(object sender, RoutedEventArgs e)
        {
            wBD.AddSource(ProductT, "SELECT Product_house.ID, Product.Name, Material.Name FROM Product, Material, Product_house" +
                " WHERE Product_id = Product.ID AND Material_id = Material.ID AND Warehouse_id = 1", 1);
        }

        private void sc2_Checked(object sender, RoutedEventArgs e)
        {
            wBD.AddSource(ProductT, "SELECT Product_house.ID, Product.Name, Material.Name FROM Product, Material, Product_house" +
                " WHERE Product_id = Product.ID AND Material_id = Material.ID AND Warehouse_id = 2", 1);
        }

        private void sc3_Checked(object sender, RoutedEventArgs e)
        {
            wBD.AddSource(ProductT, "SELECT Product_house.ID, Product.Name, Material.Name FROM Product, Material, Product_house" +
                " WHERE Product_id = Product.ID AND Material_id = Material.ID AND Warehouse_id = 3", 1);
        }

        private void sc4_Checked(object sender, RoutedEventArgs e)
        {
            wBD.AddSource(ProductT, "SELECT Product_house.ID, Product.Name, Material.Name FROM Product, Material, Product_house" +
                " WHERE Product_id = Product.ID AND Material_id = Material.ID AND Warehouse_id = 4", 1);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
