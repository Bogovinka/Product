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
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        WorkBD wBD = new WorkBD();
        public Worker()
        {
            InitializeComponent();
            wBD.AddSource(ProductT, "SELECT ID, Name FROM Product");
            wBD.AddSource(MaterialT, "SELECT ID, Name FROM Material");
            wBD.AddSource(WareHouse, "SELECT ID, Name FROM Warehouse");
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            if (ProductT.SelectedIndex > -1 && MaterialT.SelectedIndex > -1 && WareHouse.SelectedIndex > -1)
            {
                wBD.insertDBProduct(ProductT.Text[0].ToString(), MaterialT.Text[0].ToString(), WareHouse.Text[0].ToString());
                ProductT.SelectedIndex = -1;
                MaterialT.SelectedIndex = -1;
                WareHouse.SelectedIndex = -1;
            }
            else MessageBox.Show("Есть пустые поля");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
