using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    internal class Login
    {
        string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseProducts.mdf;Integrated Security=True";
        public bool userHave(string login, string pass)
        //проверка на наличие такого же логина и пароля

        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCom = new SqlCommand($"SELECT Login FROM Logins WHERE Login = '{login}' AND Password = '{pass}'", connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read()) count++;
                if (count > 0) return true;
                else return false;
            }
        }
        public bool userHave(string login)
        //проверка на наличие такого же логина и пароля

        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCom = new SqlCommand($"SELECT Login FROM Logins WHERE Login = '{login}'", connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read()) count++;
                if (count > 0) return true;
                else return false;
            }
        }
        public string typeUser(string login)
        //проверка на наличие такого же логина и пароля

        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string res = "";
                SqlCommand sqlCom = new SqlCommand($"SELECT Type_acc FROM Logins WHERE Login = '{login}'", connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read())
                {
                    res = read.GetValue(0).ToString();
                }
                return res;
            }
        }
        public int idUser(string login)
        //проверка на наличие такого же логина и пароля

        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int res = 1;
                SqlCommand sqlCom = new SqlCommand($"SELECT ID FROM Logins WHERE Login = '{login}'", connection);
                connection.Open();
                SqlDataReader read = sqlCom.ExecuteReader();
                while (read.Read())
                {
                    res = Convert.ToInt32(read.GetValue(0));
                }
                return res;
            }
        }
    }
}
