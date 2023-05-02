using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseProducts.mdf;Integrated Security=True";
        bool edit = false;
        public AddUser()
        {
            InitializeComponent();
        }
        public AddUser(string ID)
        {
            InitializeComponent();
            edit = true;
            NameT.IsEnabled = false;
            typeT.IsEnabled = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCom = new SqlCommand($"SELECT Login, Password FROM Logins WHERE ID = {ID}", connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read())
                {
                    LoginT.Text = read.GetString(0);
                    PasswordT.Text = read.GetString(1);
                }
            }
        }
        Login login = new Login();
        private void createB_Click(object sender, RoutedEventArgs e)
        {
            if (!edit)
            {
                if (NameT.Text != "" && LoginT.Text != "" && PasswordT.Text != "" && typeT.SelectedIndex > -1)
                {
                    if (!login.userHave(LoginT.Text))
                        DialogResult = true;
                    else MessageBox.Show("Такой логин уже есть");
                }
                else MessageBox.Show("Заполни все поля");
            }
            else
            {
                if (LoginT.Text != "" && PasswordT.Text != "")
                {
                    if (!login.userHave(LoginT.Text))
                        DialogResult = true;
                    else MessageBox.Show("Такой логин уже есть");
                }
                else MessageBox.Show("Заполни все поля");
            }
        }
    }
}
