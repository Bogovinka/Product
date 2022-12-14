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

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login login = new Login();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            if (login.userHave(loginText.Text, passwordText.Password))
            {
                int type = Convert.ToInt32(login.typeUser(loginText.Text));
                int idUser = login.idUser(loginText.Text);
                switch (type)
                {
                    case 1:
                        Order order = new Order();
                        order.Show();
                        Close();
                        break;
                    case 4:
                        Supplier sup = new Supplier(idUser);
                        sup.Show();
                        Close();
                        break;
                    case 3:
                        Warehouse wh = new Warehouse();
                        wh.Show();
                        Close();
                        break;
                    case 2:
                        Worker worker = new Worker();
                        worker.Show();
                        Close();
                        break;
                    case 5:
                        AdminMenu admin = new AdminMenu();
                        admin.Show();
                        Close();
                        break;
                }
            }
            else MessageBox.Show("Не верный логин или пароль");
        }
    }
}
