using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class OrderForm : Form
    {
        private int orderId = 0;
        private bool isEditing = false;

        /// <summary>
        /// Конструктор для создания нового заказа
        /// </summary>
        public OrderForm()
        {
            InitializeComponent();
            this.Text = "Добавить заказ";

            // Загружаем список товаров
            LoadProducts();

            // Устанавливаем текущую дату
            dtpOrderDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Конструктор для редактирования существующего заказа
        /// </summary>
        /// <param name="id">ID заказа</param>
        public OrderForm(int id)
        {
            InitializeComponent();
            this.Text = "Изменить заказ";
            this.orderId = id;
            this.isEditing = true;

            // Загружаем список товаров
            LoadProducts();

            // Загружаем данные заказа
            LoadOrderData();
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
        /// Загрузка данных заказа для редактирования
        /// </summary>
        private void LoadOrderData()
        {
            string query = $"SELECT * FROM product_order WHERE order_part_id = {orderId}";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Устанавливаем значения полей
                dtpOrderDate.Value = Convert.ToDateTime(row["order_date"]);
                cmbProduct.SelectedValue = row["product_id"];
                nudQuantity.Value = Convert.ToInt32(row["order_quantity"]);
                txtTotal.Text = row["order_total"].ToString();
            }
        }

        /// <summary>
        /// Обработчик изменения выбранного товара
        /// </summary>
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        /// <summary>
        /// Обработчик изменения количества товара
        /// </summary>
        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        /// <summary>
        /// Обновление общей суммы заказа
        /// </summary>
        private void UpdateTotal()
        {
            if (cmbProduct.SelectedValue != null)
            {
                int productId = Convert.ToInt32(cmbProduct.SelectedValue);
                int quantity = Convert.ToInt32(nudQuantity.Value);

                // Получаем цену товара
                string query = $"SELECT purchase_price FROM product WHERE product_id = {productId}";
                object result = DatabaseConnection.ExecuteScalar(query);

                if (result != null)
                {
                    decimal price = Convert.ToDecimal(result);
                    decimal total = price * quantity;

                    // Устанавливаем общую сумму
                    txtTotal.Text = total.ToString();
                }
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

            // Проверяем, указано ли количество
            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Пожалуйста, укажите количество товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(cmbProduct.SelectedValue);
            int quantity = Convert.ToInt32(nudQuantity.Value);
            decimal total = Convert.ToDecimal(txtTotal.Text);
            DateTime orderDate = dtpOrderDate.Value;

            try
            {
                string query;

                if (isEditing)
                {
                    // Обновляем существующий заказ
                    query = $@"UPDATE product_order 
                             SET order_date = '{orderDate:yyyy-MM-dd}', 
                             product_id = {productId}, 
                             order_quantity = {quantity}, 
                             order_total = {total.ToString().Replace(",", ".")} 
                             WHERE order_part_id = {orderId}";
                }
                else
                {
                    // Добавляем новый заказ
                    query = $@"INSERT INTO product_order 
                             (order_date, product_id, order_quantity, order_total) 
                             VALUES 
                             ('{orderDate:yyyy-MM-dd}', {productId}, {quantity}, {total.ToString().Replace(",", ".")})";
                }

                int result = DatabaseConnection.ExecuteNonQuery(query);

                if (result > 0)
                {
                    // Проверяем, существует ли товар на складе
                    string checkWarehouseQuery = $"SELECT COUNT(*) FROM warehouse WHERE product_id = {productId}";
                    int warehouseCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkWarehouseQuery));

                    if (warehouseCount > 0)
                    {
                        // Обновляем количество товара на складе
                        string updateWarehouseQuery;

                        if (isEditing)
                        {
                            // Получаем текущее количество в заказе
                            string currentQuantityQuery = $"SELECT order_quantity FROM product_order WHERE order_part_id = {orderId}";
                            int currentQuantity = Convert.ToInt32(DatabaseConnection.ExecuteScalar(currentQuantityQuery));

                            // Обновляем склад с учетом изменения количества
                            updateWarehouseQuery = $@"
                                UPDATE warehouse 
                                SET stock_quantity = stock_quantity - {quantity} + {currentQuantity} 
                                WHERE product_id = {productId}";
                        }
                        else
                        {
                            // Увеличиваем количество на складе
                            updateWarehouseQuery = $@"
                                UPDATE warehouse 
                                SET stock_quantity = stock_quantity + {quantity} 
                                WHERE product_id = {productId}";
                        }

                        DatabaseConnection.ExecuteNonQuery(updateWarehouseQuery);
                    }
                    else
                    {
                        // Добавляем товар на склад
                        string insertWarehouseQuery = $@"
                            INSERT INTO warehouse (product_id, stock_quantity) 
                            VALUES ({productId}, {quantity})";

                        DatabaseConnection.ExecuteNonQuery(insertWarehouseQuery);
                    }

                    MessageBox.Show("Заказ успешно сохранен.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить заказ.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении заказа: " + ex.Message, "Ошибка",
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