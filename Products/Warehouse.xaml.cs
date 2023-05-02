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
    /// Логика взаимодействия для Warehouse.xaml
    /// </summary>
    public partial class Warehouse : Window
    {
        public Warehouse()
        {
            InitializeComponent();
            WorkBD wBD = new WorkBD();
            wBD.relDTWarehouse(dG);
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
        WorkBD wBD = new WorkBD();
        private void editNote_Click(object sender, RoutedEventArgs e)
        {
            if (dG.SelectedItem != null)
            {
                DataRowView dGR = (DataRowView)dG.SelectedItem;
                string id = dGR["Описание"].ToString();
                EditNote aU = new EditNote(id);
                aU.ShowDialog();
                if (aU.DialogResult == true)
                {
                    wBD.updateNote(aU.noteT.Text, id);
                    wBD.relDTWarehouse(dG);
                }
            }
        }
    }
}
