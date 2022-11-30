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
    /// Логика взаимодействия для Supplier.xaml
    /// </summary>
    public partial class Supplier : Window
    {
        WorkBD wBD = new WorkBD();
        int idSup;
        public Supplier(int id)
        {
            InitializeComponent();
            idSup = id;
            wBD.relDTOrder(dGSup, idSup.ToString());
        }

        private void editWorker_Click(object sender, RoutedEventArgs e)
        {
            if (dGSup.SelectedItem != null)
            {
                EditStatus eS = new EditStatus();
                eS.ShowDialog();
                if (eS.DialogResult == true)
                {
                    DataRowView dGR = (DataRowView)dGSup.SelectedItem;
                    wBD.updateStatus(eS.statusCB.Text[0].ToString(), dGR["ID"].ToString());
                    wBD.relDTOrder(dGSup, idSup.ToString());
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
    }
}
