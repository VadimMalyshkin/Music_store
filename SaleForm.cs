using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class SaleForm : Form
    {
        private int saleId = 0;
        private int shiftId = 0;
        private bool isEditing = false;
        private decimal oldSaleTotal = 0;

        /// <summary>
        /// Конструктор для создания новой продажи
        /// </summary>
        /// <param name="currentShiftId">ID текущей смены</param>
        public SaleForm(int currentShiftId)
        {
            InitializeComponent();
            this.Text = "Добавить продажу";
            this.shiftId = currentShiftId;

            // Загружаем список товаров
            LoadProducts();

            // Устанавливаем текущую дату и время
            dtpSaleDateTime.Value = DateTime.Now;

            // Делаем поле смены недоступным для редактирования
            txtShiftId.Text = currentShiftId.ToString();
            txtShiftId.ReadOnly = true;
        }

        /// <summary>
        /// Конструктор для редактирования существующей продажи
        /// </summary>
        /// <param name="id">ID продажи</param>
        /// <param name="currentShiftId">ID смены</param>
        public SaleForm(int id, int currentShiftId)
        {
            InitializeComponent();
            this.Text = "Изменить продажу";
            this.saleId = id;
            this.shiftId = currentShiftId;
            this.isEditing = true;

            // Загружаем список товаров
            LoadProducts();

            // Загружаем данные продажи
            LoadSaleData();

            // Делаем поле смены недоступным для редактирования
            txtShiftId.ReadOnly = true;
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
        /// Загрузка данных продажи для редактирования
        /// </summary>
        private void LoadSaleData()
        {
            string query = $"SELECT * FROM sale WHERE sale_id = {saleId}";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Устанавливаем значения полей
                dtpSaleDateTime.Value = Convert.ToDateTime(row["sale_datetime"]);
                txtShiftId.Text = row["shift_id"].ToString();
                cmbProduct.SelectedValue = row["product_id"];
                nudQuantity.Value = Convert.ToInt32(row["sale_quantity"]);
                txtTotal.Text = row["sale_total"].ToString();

                // Сохраняем старую сумму продажи для обновления выручки смены
                oldSaleTotal = Convert.ToDecimal(row["sale_total"]);
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
        /// Обновление общей суммы продажи
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
            DateTime saleDateTime = dtpSaleDateTime.Value;

            // Проверяем наличие товара на складе
            string checkStockQuery = $"SELECT stock_quantity FROM warehouse WHERE product_id = {productId}";
            object stockResult = DatabaseConnection.ExecuteScalar(checkStockQuery);

            if (stockResult == null)
            {
                MessageBox.Show("Товар отсутствует на складе.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stockQuantity = Convert.ToInt32(stockResult);

            // Если редактируем, учитываем текущее количество в продаже
            if (isEditing)
            {
                string currentQuantityQuery = $"SELECT sale_quantity FROM sale WHERE sale_id = {saleId}";
                int currentQuantity = Convert.ToInt32(DatabaseConnection.ExecuteScalar(currentQuantityQuery));

                // Добавляем текущее количество обратно к доступному
                stockQuantity += currentQuantity;
            }

            if (quantity > stockQuantity)
            {
                MessageBox.Show($"Недостаточно товара на складе. Доступно: {stockQuantity}", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query;

                if (isEditing)
                {
                    // Обновляем существующую продажу
                    query = $@"UPDATE sale 
                             SET sale_datetime = '{saleDateTime:yyyy-MM-dd HH:mm:ss}', 
                             product_id = {productId}, 
                             sale_quantity = {quantity}, 
                             sale_total = {total.ToString().Replace(",", ".")} 
                             WHERE sale_id = {saleId}";
                }
                else
                {
                    // Добавляем новую продажу
                    query = $@"INSERT INTO sale 
                             (sale_datetime, shift_id, product_id, sale_quantity, sale_total) 
                             VALUES 
                             ('{saleDateTime:yyyy-MM-dd HH:mm:ss}', {shiftId}, {productId}, {quantity}, {total.ToString().Replace(",", ".")})";
                }

                int result = DatabaseConnection.ExecuteNonQuery(query);

                if (result > 0)
                {
                    // Обновляем количество товара на складе
                    string updateWarehouseQuery;

                    if (isEditing)
                    {
                        // Получаем текущее количество в продаже
                        string currentQuantityQuery = $"SELECT sale_quantity FROM sale WHERE sale_id = {saleId}";
                        int currentQuantity = Convert.ToInt32(DatabaseConnection.ExecuteScalar(currentQuantityQuery));

                        // Обновляем склад с учетом изменения количества
                        updateWarehouseQuery = $@"
                            UPDATE warehouse 
                            SET stock_quantity = stock_quantity + {currentQuantity} - {quantity} 
                            WHERE product_id = {productId}";
                    }
                    else
                    {
                        // Уменьшаем количество на складе
                        updateWarehouseQuery = $@"
                            UPDATE warehouse 
                            SET stock_quantity = stock_quantity - {quantity} 
                            WHERE product_id = {productId}";
                    }

                    DatabaseConnection.ExecuteNonQuery(updateWarehouseQuery);

                    // Обновляем выручку смены
                    string updateShiftQuery;

                    if (isEditing)
                    {
                        // Обновляем выручку с учетом изменения суммы продажи
                        updateShiftQuery = $@"
                            UPDATE shift 
                            SET total_revenue = total_revenue - {oldSaleTotal.ToString().Replace(",", ".")} + {total.ToString().Replace(",", ".")} 
                            WHERE shift_id = {shiftId}";
                    }
                    else
                    {
                        // Увеличиваем выручку смены
                        updateShiftQuery = $@"
                            UPDATE shift 
                            SET total_revenue = total_revenue + {total.ToString().Replace(",", ".")} 
                            WHERE shift_id = {shiftId}";
                    }

                    DatabaseConnection.ExecuteNonQuery(updateShiftQuery);

                    MessageBox.Show("Продажа успешно сохранена.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить продажу.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении продажи: " + ex.Message, "Ошибка",
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