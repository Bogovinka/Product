using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Products
{
    internal class WorkBD
    {
        string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseProducts.mdf;Integrated Security=True";

        public void AddSource(ComboBox cB, string select)
        {
            var list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCom = new SqlCommand(select, connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read())
                {
                    list.Add($"{read.GetValue(0)} - {read.GetString(1)}");
                }
            }
            cB.ItemsSource = list;
        }
        public void AddSource(ComboBox cB, string select, int i)
        {
            var list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCom = new SqlCommand(select, connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read())
                {
                    list.Add($"{read.GetValue(0)} - {read.GetString(1)} - {read.GetString(2)}");
                }
            }
            cB.ItemsSource = list;
        }
        public void relDTOrder(DataGrid dg, string where)
        {
            dg.Columns.Clear();
            string sql = $"SELECT Order_Sup.ID, Logins.Name AS 'Поставщик', Product.Name AS 'Товар', Material.Name AS 'Материал', Warehouse.Name AS 'Склад', Answer.Name AS 'Заявка'" +
                $" FROM Logins, Product, Material, Warehouse, Order_Sup, Answer, Product_house" +
                $" WHERE Supplier_id = Logins.ID AND Supplier_id = {where} AND Product_id = Product.ID AND Material_id = Material.ID AND Warehouse_id = Warehouse.ID AND Answer_id = Answer.ID AND Product_house_id = Product_house.ID";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdSel = new SqlCommand(sql, connection);
            DataTable dataTab = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdSel);
            da.Fill(dataTab);
            dg.ItemsSource = dataTab.DefaultView;
        }

        public void relDTWarehouse(DataGrid dg)
        {
            dg.Columns.Clear();
            string sql = $"SELECT Product.Name AS 'Товар', Material.Name AS 'Материал', Warehouse.Name AS 'Склад', Product.Create_not AS 'Описание'" +
                $" FROM Product, Material, Warehouse, Product_house" +
                $" WHERE Product_id = Product.ID AND Material_id = Material.ID AND Warehouse_id = Warehouse.ID";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdSel = new SqlCommand(sql, connection);
            DataTable dataTab = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdSel);
            da.Fill(dataTab);
            dg.ItemsSource = dataTab.DefaultView;
        }
        public void relDTProducts(DataGrid dg)
        {
            dg.Columns.Clear();
            string sql = $"SELECT Name, Create_not FROM Product";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdSel = new SqlCommand(sql, connection);
            DataTable dataTab = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdSel);
            da.Fill(dataTab);
            dg.ItemsSource = dataTab.DefaultView;
        }

        //метод добавление данных в БД
        public void insertDB(string product, string login)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"INSERT INTO Order_Sup" +
                    $" VALUES ('{product}', '{login}', '1')";
                SqlCommand command = new SqlCommand(query, connection);
                // выполняем запрос
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertDBProduct(string product, string material, string warehouse)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"INSERT INTO Product_house" +
                    $" VALUES ('{product}', '{material}', '{warehouse}')";
                SqlCommand command = new SqlCommand(query, connection);
                // выполняем запрос
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateStatus(string name, string where)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"UPDATE Order_Sup SET Answer_id = '{name}' WHERE ID = '{where}'";
                SqlCommand command = new SqlCommand(query, connection);
                // выполняем запрос
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void relDTUsers(DataGrid dg)
        {
            dg.Columns.Clear();
            string sql = $"SELECT ID, Name, Login, Password FROM Logins";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmdSel = new SqlCommand(sql, connection);
            DataTable dataTab = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdSel);
            da.Fill(dataTab);
            dg.ItemsSource = dataTab.DefaultView;
        }

        public void insertDB(string Name, string Type_acc, string Login, string Password)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"INSERT INTO Logins" +
                    $" VALUES (N'{Name}', '{Type_acc}', N'{Login}', N'{Password}')";
                SqlCommand command = new SqlCommand(query, connection);
                // выполняем запрос
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updateUser(string Login, string Password, string ID)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"UPDATE Logins" +
                    $" SET Login = N'{Login}', Password = N'{Password}' WHERE ID = {ID}";
                SqlCommand command = new SqlCommand(query, connection);
                // выполняем запрос
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updateNote(string note, string notes)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"UPDATE Product" +
                    $" SET Create_not = N'{note}' WHERE Create_not = N'{notes}'";
                SqlCommand command = new SqlCommand(query, connection);
                // выполняем запрос
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void deleteUser(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCom2 = new SqlCommand($"DELETE FROM Order_Sup WHERE Supplier_id = '{id}'", connection);
                    SqlCommand sqlCom = new SqlCommand($"DELETE FROM Logins WHERE ID = '{id}'", connection);
                    connection.Open();
                    sqlCom2.ExecuteNonQuery();
                    sqlCom.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
