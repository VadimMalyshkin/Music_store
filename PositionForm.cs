using System;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class PositionForm : Form
    {
        private int positionId = 0;
        private bool isEditing = false;

        /// <summary>
        /// Конструктор для создания новой должности
        /// </summary>
        public PositionForm()
        {
            InitializeComponent();
            this.Text = "Добавить должность";
        }

        /// <summary>
        /// Конструктор для редактирования существующей должности
        /// </summary>
        /// <param name="id">ID должности</param>
        /// <param name="name">Название должности</param>
        public PositionForm(int id, string name)
        {
            InitializeComponent();
            this.Text = "Изменить должность";
            this.positionId = id;
            this.isEditing = true;
            txtPositionName.Text = name;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtPositionName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, введите название должности.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, существует ли уже такое название
            string checkQuery = $"SELECT COUNT(*) FROM position WHERE position_name = '{name}'";
            if (isEditing)
            {
                checkQuery += $" AND position_id != {positionId}";
            }

            int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery));
            if (count > 0)
            {
                MessageBox.Show($"Должность с названием '{name}' уже существует.",
                    "Дублирование названия", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            if (isEditing)
            {
                query = $"UPDATE position SET position_name = '{name}' WHERE position_id = {positionId}";
            }
            else
            {
                query = $"INSERT INTO position (position_name) VALUES ('{name}')";
            }

            int result = DatabaseConnection.ExecuteNonQuery(query);

            if (result > 0)
            {
                MessageBox.Show("Должность успешно сохранена.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось сохранить должность.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена"
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}