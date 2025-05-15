using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class ProductForm : Form
    {
        private int productId = 0;
        private bool isEditing = false;

        /// <summary>
        /// Конструктор для создания нового товара
        /// </summary>
        public ProductForm()
        {
            InitializeComponent();
            this.Text = "Добавить товар";

            // Загружаем список типов товаров
            LoadProductTypes();
        }

        /// <summary>
        /// Конструктор для редактирования существующего товара
        /// </summary>
        /// <param name="id">ID товара</param>
        public ProductForm(int id)
        {
            InitializeComponent();
            this.Text = "Изменить товар";
            this.productId = id;
            this.isEditing = true;

            // Загружаем список типов товаров
            LoadProductTypes();

            // Загружаем данные товара
            LoadProductData();
        }

        /// <summary>
        /// Загрузка списка типов товаров для комбобокса
        /// </summary>
        private void LoadProductTypes()
        {
            string query = "SELECT product_type_id, product_type_name FROM product_type ORDER BY product_type_name";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbProductType.DataSource = dt;
            cmbProductType.DisplayMember = "product_type_name";
            cmbProductType.ValueMember = "product_type_id";
        }

        /// <summary>
        /// Загрузка данных товара для редактирования
        /// </summary>
        private void LoadProductData()
        {
            string query = $"SELECT * FROM product WHERE product_id = {productId}";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Устанавливаем значения полей
                txtProductSku.Text = row["product_sku"].ToString();
                txtProductName.Text = row["product_name"].ToString();
                cmbProductType.SelectedValue = row["product_type_id"];
                txtBrand.Text = row["brand"].ToString();
                nudPurchasePrice.Value = Convert.ToDecimal(row["purchase_price"]);

                // Делаем поле артикула недоступным для редактирования
                txtProductSku.ReadOnly = true;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных полей
            if (string.IsNullOrEmpty(txtProductSku.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста, введите артикул товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста, введите название товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProductType.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudPurchasePrice.Value <= 0)
            {
                MessageBox.Show("Пожалуйста, укажите цену товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productSku = txtProductSku.Text.Trim();
            string productName = txtProductName.Text.Trim();
            int productTypeId = Convert.ToInt32(cmbProductType.SelectedValue);
            string brand = txtBrand.Text.Trim();
            decimal purchasePrice = nudPurchasePrice.Value;

            try
            {
                // Проверяем уникальность артикула
                string checkSkuQuery = $"SELECT COUNT(*) FROM product WHERE product_sku = '{productSku}'";
                if (isEditing)
                {
                    checkSkuQuery += $" AND product_id != {productId}";
                }

                int skuCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkSkuQuery));
                if (skuCount > 0)
                {
                    MessageBox.Show($"Товар с артикулом '{productSku}' уже существует.",
                        "Дублирование артикула", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query;

                if (isEditing)
                {
                    // Обновляем существующий товар
                    query = $@"UPDATE product 
                             SET product_name = '{productName}', 
                             product_type_id = {productTypeId}, 
                             brand = '{brand}', 
                             purchase_price = {purchasePrice.ToString().Replace(",", ".")} 
                             WHERE product_id = {productId}";
                }
                else
                {
                    // Добавляем новый товар
                    query = $@"INSERT INTO product 
                             (product_sku, product_name, product_type_id, brand, purchase_price) 
                             VALUES 
                             ('{productSku}', '{productName}', {productTypeId}, '{brand}', {purchasePrice.ToString().Replace(",", ".")})";
                }

                int result = DatabaseConnection.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Товар успешно сохранен.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить товар.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении товара: " + ex.Message, "Ошибка",
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