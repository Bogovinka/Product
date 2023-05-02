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
    /// Логика взаимодействия для EditNote.xaml
    /// </summary>
    public partial class EditNote : Window
    {
        public EditNote(string s)
        {
            InitializeComponent();
            noteT.Text = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
