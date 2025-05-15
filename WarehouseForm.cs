using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class WarehouseForm : Form
    {
        private int warehouseId = 0;
        private bool isEditing = false;

        /// <summary>
        /// Конструктор для добавления нового товара на склад
        /// </summary>
        public WarehouseForm()
        {
            InitializeComponent();
            this.Text = "Добавить товар на склад";

            // Загружаем список товаров
            LoadProducts();
        }

        /// <summary>
        /// Конструктор для редактирования существующего товара на складе
        /// </summary>
        /// <param name="id">ID записи склада</param>
        public WarehouseForm(int id)
        {
            InitializeComponent();
            this.Text = "Изменить товар на складе";
            this.warehouseId = id;
            this.isEditing = true;

            // Загружаем список товаров
            LoadProducts();

            // Загружаем данные товара на складе
            LoadWarehouseData();
        }

        /// <summary>
        /// Загрузка списка товаров для комбобокса
        /// </summary>
        private void LoadProducts()
        {
            string query = @"SELECT p.product_id, 
                           CONCAT(p.product_name, ' (', p.product_sku, ') - ', pt.product_type_name, ' - ', p.brand) as product_full_name
                           FROM product p
                           JOIN product_type pt ON p.product_type_id = pt.product_type_id
                           ORDER BY p.product_name";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbProduct.DataSource = dt;
            cmbProduct.DisplayMember = "product_full_name";
            cmbProduct.ValueMember = "product_id";
        }

        /// <summary>
        /// Загрузка данных товара на складе для редактирования
        /// </summary>
        private void LoadWarehouseData()
        {
            string query = $"SELECT * FROM warehouse WHERE warehouse_id = {warehouseId}";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Устанавливаем значения полей
                cmbProduct.SelectedValue = row["product_id"];
                nudQuantity.Value = Convert.ToInt32(row["stock_quantity"]);

                // Делаем комбобокс товаров недоступным для редактирования
                cmbProduct.Enabled = false;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли товар
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(cmbProduct.SelectedValue);
            int quantity = Convert.ToInt32(nudQuantity.Value);

            try
            {
                string query;

                if (isEditing)
                {
                    // Обновляем существующую запись склада
                    query = $@"UPDATE warehouse 
                             SET stock_quantity = {quantity} 
                             WHERE warehouse_id = {warehouseId}";
                }
                else
                {
                    // Проверяем, существует ли уже товар на складе
                    string checkQuery = $"SELECT COUNT(*) FROM warehouse WHERE product_id = {productId}";
                    int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery));

                    if (count > 0)
                    {
                        // Обновляем существующую запись
                        query = $@"UPDATE warehouse 
                                 SET stock_quantity = stock_quantity + {quantity} 
                                 WHERE product_id = {productId}";
                    }
                    else
                    {
                        // Добавляем новую запись
                        query = $@"INSERT INTO warehouse 
                                 (product_id, stock_quantity) 
                                 VALUES 
                                 ({productId}, {quantity})";
                    }
                }

                int result = DatabaseConnection.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Товар на складе успешно сохранен.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить товар на складе.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении товара на складе: " + ex.Message, "Ошибка",
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