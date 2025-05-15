using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace MusicStoreWarehouse
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка входа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Хешируем пароль для сравнения
            string hashedPassword = HashPassword(password);

            // Проверяем учетные данные в базе данных
            try
            {
                // Получаем информацию о пользователе, включая роль
                string query = @"SELECT e.employee_id, e.full_name, p.position_name 
                               FROM employee e 
                               JOIN position p ON e.position_id = p.position_id 
                               WHERE e.login = @username AND e.password_hash = @password";

                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0);
                                string fullName = reader.GetString(1);
                                string positionName = reader.GetString(2);

                                // Вход успешен
                                MainForm mainForm = new MainForm(employeeId, positionName);
                                this.Hide();
                                mainForm.FormClosed += (s, args) => this.Close();
                                mainForm.Show();

                                return;
                            }
                        }
                    }
                }

                // Если мы дошли до этой точки, значит учетные данные неверны
                MessageBox.Show("Неверный логин или пароль.", "Ошибка входа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}