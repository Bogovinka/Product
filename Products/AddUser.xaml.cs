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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }
        Login login = new Login();
        private void createB_Click(object sender, RoutedEventArgs e)
        {
            if (NameT.Text != "" && LoginT.Text != "" && PasswordT.Text != "" && typeT.SelectedIndex > -1)
            {
                if (!login.userHave(LoginT.Text))
                    DialogResult = true;
                else MessageBox.Show("Такой логин уже есть");
            }
            else MessageBox.Show("Заполни все поля");
        }
    }
}
