using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    /// <summary>
    /// Класс для работы с базой данных PostgreSQL
    /// </summary>
    public class DatabaseConnection
    {
        // Строка подключения к базе данных
        private static readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=0987654321;Database=MusicStoreWarehouse";

        /// <summary>
        /// Получение подключения к базе данных
        /// </summary>
        /// <returns>Объект подключения к базе данных</returns>
        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            return connection;
        }

        /// <summary>
        /// Выполнение запроса с возвратом таблицы данных
        /// </summary>
        /// <param name="query">SQL-запрос</param>
        /// <returns>Таблица с результатами запроса</returns>
        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                using (NpgsqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Выполнение запроса без возврата данных
        /// </summary>
        /// <param name="query">SQL-запрос</param>
        /// <returns>Количество затронутых строк</returns>
        public static int ExecuteNonQuery(string query)
        {
            try
            {
                using (NpgsqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// Выполнение запроса с возвратом скалярного значения
        /// </summary>
        /// <param name="query">SQL-запрос</param>
        /// <returns>Результат запроса</returns>
        public static object ExecuteScalar(string query)
        {
            try
            {
                using (NpgsqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}