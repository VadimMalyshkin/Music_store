using System;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class ProductTypeForm : Form
    {
        private int productTypeId = 0;
        private bool isEditing = false;

        public ProductTypeForm()
        {
            InitializeComponent();
            this.Text = "Добавить тип товара";
        }

        public ProductTypeForm(int id, string name)
        {
            InitializeComponent();
            this.Text = "Изменить тип товара";
            this.productTypeId = id;
            this.isEditing = true;
            txtProductTypeName.Text = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtProductTypeName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, введите название типа товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, существует ли уже такое название
            string checkQuery = $"SELECT COUNT(*) FROM product_type WHERE product_type_name = '{name}'";
            if (isEditing)
            {
                checkQuery += $" AND product_type_id != {productTypeId}";
            }

            int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery));
            if (count > 0)
            {
                MessageBox.Show($"Тип товара с названием '{name}' уже существует.",
                    "Дублирование названия", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            if (isEditing)
            {
                query = $"UPDATE product_type SET product_type_name = '{name}' WHERE product_type_id = {productTypeId}";
            }
            else
            {
                query = $"INSERT INTO product_type (product_type_name) VALUES ('{name}')";
            }

            int result = DatabaseConnection.ExecuteNonQuery(query);

            if (result > 0)
            {
                MessageBox.Show("Тип товара успешно сохранен.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось сохранить тип товара.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}