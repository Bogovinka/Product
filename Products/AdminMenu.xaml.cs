using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        Login login = new Login();
        WorkBD wBD = new WorkBD();
        public AdminMenu()
        {
            InitializeComponent();
            wBD.relDTUsers(dGUsers);
        }
        private void addWorker_Click(object sender, RoutedEventArgs e)
        {
            AddUser aU = new AddUser();
            aU.ShowDialog();
            if(aU.DialogResult == true)
            {
                wBD.insertDB(aU.NameT.Text, (aU.typeT.SelectedIndex + 1).ToString(), aU.LoginT.Text, aU.PasswordT.Text);
                wBD.relDTUsers(dGUsers);
            }
        }

        private void deleteWorker_Click(object sender, RoutedEventArgs e)
        {
            if (dGUsers.SelectedItem != null)
            {
                DataRowView dGR = (DataRowView)dGUsers.SelectedItem;
                if (dGR["Login"].ToString() != "admin") {
                    wBD.deleteUser(dGR["ID"].ToString());
                    dGR.Delete();
                }
            }
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

        private void editWorker_Click(object sender, RoutedEventArgs e)
        {
            if (dGUsers.SelectedItem != null)
            {
                DataRowView dGR = (DataRowView)dGUsers.SelectedItem;
                string id = dGR["ID"].ToString();
                AddUser aU = new AddUser(id);
                aU.ShowDialog();
                if (aU.DialogResult == true)
                {
                    wBD.updateUser(aU.LoginT.Text, aU.PasswordT.Text, id);
                    wBD.relDTUsers(dGUsers);
                }
            }
        }
    }
}
