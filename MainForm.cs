using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MusicStoreWarehouse
{
    public partial class MainForm : Form
    {
        // Текущая активная смена
        private int currentShiftId = -1;
        // Текущий пользователь
        private int currentEmployeeId = -1;
        // Роль текущего пользователя
        private string currentEmployeeRole = "";

        public MainForm(int employeeId, string role)
        {
            InitializeComponent();

            // Сохраняем ID и роль текущего пользователя
            currentEmployeeId = employeeId;
            currentEmployeeRole = role;

            // Настраиваем доступ к функциям в зависимости от роли
            SetupAccessRights();
        }

        /// <summary>
        /// Настройка прав доступа в зависимости от роли пользователя
        /// </summary>
        private void SetupAccessRights()
        {
            // Если пользователь не администратор
            if (currentEmployeeRole != "Администратор")
            {
                // Скрываем вкладку сотрудников
                btnEmployees.Visible = false;
                // Скрываем вкладку должностей
                btnPositions.Visible = false;

                // Отключаем контекстное меню для редактирования смен
                cmShifts.Items["editShiftToolStripMenuItem"].Enabled = false;
                cmShifts.Items["addShiftToolStripMenuItem"].Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Загрузка начальных данных
            LoadProductTypes();

            // Настройка комбобоксов для фильтрации
            SetupFilterComboBoxes();

            // Активируем кнопку начала смены
            btnStartShift.Enabled = true;
        }

        /// <summary>
        /// Настройка комбобоксов для фильтрации по столбцам
        /// </summary>
        private void SetupFilterComboBoxes()
        {
            // Настраиваем комбобоксы для всех таблиц
            SetupFilterComboBox(cmbFilterEmployees, dgvEmployees);
            SetupFilterComboBox(cmbFilterPositions, dgvPositions);
            SetupFilterComboBox(cmbFilterProducts, dgvProducts);
            SetupFilterComboBox(cmbFilterProductTypes, dgvProductTypes);
            SetupFilterComboBox(cmbFilterWarehouse, dgvWarehouse);
            SetupFilterComboBox(cmbFilterSales, dgvSales);
            SetupFilterComboBox(cmbFilterOrders, dgvOrders);
            SetupFilterComboBox(cmbFilterShifts, dgvShifts);
        }

        /// <summary>
        /// Настройка комбобокса для фильтрации по столбцам конкретной таблицы
        /// </summary>
        private void SetupFilterComboBox(ComboBox comboBox, DataGridView dataGridView)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Все столбцы");

            // Если в таблице есть данные
            if (dataGridView.Columns.Count > 0)
            {
                // Добавляем все столбцы, кроме ID
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (!column.Name.EndsWith("_id") && !column.Name.Equals("id"))
                    {
                        comboBox.Items.Add(column.HeaderText);
                    }
                }
            }

            // По умолчанию выбираем "Все столбцы"
            comboBox.SelectedIndex = 0;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Подтверждение выхода
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из системы?", "Подтверждение выхода",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Возврат к форме входа
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        /// <summary>
        /// Обработчик закрытия формы
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если закрытие не вызвано программно
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Запрашиваем подтверждение
                DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?",
                    "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Если пользователь отменил выход
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Начать новую смену
        /// </summary>
        private void btnStartShift_Click(object sender, EventArgs e)
        {
            // Проверяем, не активна ли уже смена
            if (currentShiftId != -1)
            {
                MessageBox.Show("Смена уже начата.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Текущая дата
            DateTime currentDate = DateTime.Now;

            // Запрос на добавление новой смены
            string query = $@"INSERT INTO shift (shift_date, employee_id, total_revenue) 
                           VALUES ('{currentDate:yyyy-MM-dd}', {currentEmployeeId}, 0) 
                           RETURNING shift_id";

            // Выполняем запрос и получаем ID новой смены
            object result = DatabaseConnection.ExecuteScalar(query);

            if (result != null)
            {
                currentShiftId = Convert.ToInt32(result);

                // Обновляем статус смены
                lblCurrentShift.Text = $"Текущая смена: #{currentShiftId} от {currentDate:dd.MM.yyyy}";

                // Отключаем кнопку начала смены
                btnStartShift.Enabled = false;

                // Обновляем список смен
                LoadShifts();

                MessageBox.Show("Смена успешно начата.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось начать смену.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Выбор вкладок
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabEmployees;
            LoadEmployees();
        }

        private void btnPositions_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPositions;
            LoadPositions();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabProducts;
            LoadProducts();
        }

        private void btnProductTypes_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabProductTypes;
            LoadProductTypes();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabWarehouse;
            LoadWarehouse();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabSales;
            LoadSales();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabOrders;
            LoadOrders();
        }

        private void btnShifts_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabShifts;
            LoadShifts();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabReports;
        }
        #endregion

        #region Методы загрузки данных
        private void LoadEmployees()
        {
            string query = @"SELECT e.employee_id, e.full_name, e.contact_number, 
                           p.position_name, e.hire_date, e.login 
                           FROM employee e 
                           JOIN position p ON e.position_id = p.position_id
                           ORDER BY e.employee_id";

            dgvEmployees.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvEmployees, cmEmployees);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterEmployees, dgvEmployees);
        }

        private void LoadPositions()
        {
            string query = "SELECT position_id, position_name FROM position ORDER BY position_id";
            dgvPositions.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvPositions, cmPositions);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterPositions, dgvPositions);
        }

        private void LoadProducts()
        {
            string query = @"SELECT p.product_id, p.product_sku, p.product_name, 
                           pt.product_type_name, p.brand, p.purchase_price
                           FROM product p
                           JOIN product_type pt ON p.product_type_id = pt.product_type_id
                           ORDER BY p.product_id";

            dgvProducts.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvProducts, cmProducts);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterProducts, dgvProducts);
        }

        private void LoadProductTypes()
        {
            string query = "SELECT product_type_id, product_type_name FROM product_type ORDER BY product_type_id";
            dgvProductTypes.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvProductTypes, cmProductTypes);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterProductTypes, dgvProductTypes);
        }

        private void LoadWarehouse()
        {
            // Обновленный запрос для отображения полной информации о товарах
            string query = @"SELECT w.warehouse_id, p.product_id, p.product_sku, p.product_name, 
                           pt.product_type_name, p.brand, p.purchase_price, w.stock_quantity
                           FROM warehouse w
                           JOIN product p ON w.product_id = p.product_id
                           JOIN product_type pt ON p.product_type_id = pt.product_type_id
                           ORDER BY w.warehouse_id";

            dgvWarehouse.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvWarehouse, cmWarehouse);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterWarehouse, dgvWarehouse);
        }

        private void LoadSales()
        {
            // Обновленный запрос для отображения полной информации о товарах
            string query = @"SELECT s.sale_id, s.sale_datetime, sh.shift_id, e.full_name as employee, 
                           p.product_id, p.product_sku, p.product_name, pt.product_type_name, 
                           p.brand, p.purchase_price, s.sale_quantity, s.sale_total
                           FROM sale s
                           JOIN shift sh ON s.shift_id = sh.shift_id
                           JOIN employee e ON sh.employee_id = e.employee_id
                           JOIN product p ON s.product_id = p.product_id
                           JOIN product_type pt ON p.product_type_id = pt.product_type_id
                           ORDER BY s.sale_datetime DESC";

            dgvSales.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvSales, cmSales);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterSales, dgvSales);
        }

        private void LoadOrders()
        {
            // Обновленный запрос для отображения полной информации о товарах
            string query = @"SELECT o.order_part_id, o.order_date, 
                           p.product_id, p.product_sku, p.product_name, pt.product_type_name, 
                           p.brand, p.purchase_price, o.order_quantity, o.order_total
                           FROM product_order o
                           JOIN product p ON o.product_id = p.product_id
                           JOIN product_type pt ON p.product_type_id = pt.product_type_id
                           ORDER BY o.order_date DESC";

            dgvOrders.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvOrders, cmOrders);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterOrders, dgvOrders);
        }

        private void LoadShifts()
        {
            string query = @"SELECT s.shift_id, s.shift_date, e.full_name as employee, s.total_revenue
                           FROM shift s
                           JOIN employee e ON s.employee_id = e.employee_id
                           ORDER BY s.shift_date DESC";

            dgvShifts.DataSource = DatabaseConnection.ExecuteQuery(query);

            // Настройка контекстного меню
            SetupContextMenu(dgvShifts, cmShifts);

            // Обновляем комбобокс для фильтрации
            SetupFilterComboBox(cmbFilterShifts, dgvShifts);
        }
        #endregion

        #region Настройка контекстного меню
        private void SetupContextMenu(DataGridView dgv, ContextMenuStrip cms)
        {
            dgv.ContextMenuStrip = cms;
        }
        #endregion

        #region Обработчики событий контекстного меню
        // Типы товаров
        private void addProductTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductTypeForm form = new ProductTypeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProductTypes();
            }
        }

        private void editProductTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProductTypes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProductTypes.SelectedRows[0].Cells["product_type_id"].Value);
                string name = dgvProductTypes.SelectedRows[0].Cells["product_type_name"].Value.ToString();

                ProductTypeForm form = new ProductTypeForm(id, name);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProductTypes();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тип товара для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteProductTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProductTypes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProductTypes.SelectedRows[0].Cells["product_type_id"].Value);
                string name = dgvProductTypes.SelectedRows[0].Cells["product_type_name"].Value.ToString();

                // Проверяем, используется ли тип товара
                string checkQuery = $"SELECT COUNT(*) FROM product WHERE product_type_id = {id}";
                int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery));

                if (count > 0)
                {
                    MessageBox.Show($"Невозможно удалить тип товара '{name}', так как он используется в {count} товарах.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить тип товара '{name}'?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM product_type WHERE product_type_id = {id}";
                    int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteQuery);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Тип товара успешно удален.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProductTypes();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тип товара для удаления.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Товары
        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["product_id"].Value);

                ProductForm form = new ProductForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["product_id"].Value);
                string name = dgvProducts.SelectedRows[0].Cells["product_name"].Value.ToString();

                // Проверяем наличие товара на складе
                string checkWarehouseQuery = $"SELECT stock_quantity FROM warehouse WHERE product_id = {id}";
                object result = DatabaseConnection.ExecuteScalar(checkWarehouseQuery);

                if (result != null && Convert.ToInt32(result) > 0)
                {
                    MessageBox.Show($"Невозможно удалить товар '{name}', так как он есть на складе.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем наличие продаж товара
                string checkSalesQuery = $"SELECT COUNT(*) FROM sale WHERE product_id = {id}";
                int salesCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkSalesQuery));

                if (salesCount > 0)
                {
                    MessageBox.Show($"Невозможно удалить товар '{name}', так как у него есть {salesCount} записей о продажах.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем наличие заказов товара
                string checkOrdersQuery = $"SELECT COUNT(*) FROM product_order WHERE product_id = {id}";
                int ordersCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkOrdersQuery));

                if (ordersCount > 0)
                {
                    MessageBox.Show($"Невозможно удалить товар '{name}', так как у него есть {ordersCount} записей о заказах.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить товар '{name}'?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Сначала удаляем запись со склада, если она существует (с нулевым количеством)
                    string deleteWarehouseQuery = $"DELETE FROM warehouse WHERE product_id = {id}";
                    DatabaseConnection.ExecuteNonQuery(deleteWarehouseQuery);

                    // Затем удаляем товар
                    string deleteProductQuery = $"DELETE FROM product WHERE product_id = {id}";
                    int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteProductQuery);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Товар успешно удален.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Склад
        private void addWarehouseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarehouseForm form = new WarehouseForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadWarehouse();
            }
        }

        private void editWarehouseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvWarehouse.SelectedRows[0].Cells["warehouse_id"].Value);

                WarehouseForm form = new WarehouseForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadWarehouse();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар на складе для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Продажи
        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, начата ли смена
            if (currentShiftId == -1)
            {
                MessageBox.Show("Пожалуйста, начните смену перед добавлением продажи.", "Требуется смена",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaleForm form = new SaleForm(currentShiftId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSales();
                LoadWarehouse(); // Обновляем данные склада, так как изменились остатки
                LoadShifts(); // Обновляем данные о сменах, так как изменилась выручка

                // Обновляем информацию о текущей смене
                UpdateCurrentShiftInfo();
            }
        }

        /// <summary>
        /// Обновление информации о текущей смене
        /// </summary>
        private void UpdateCurrentShiftInfo()
        {
            if (currentShiftId != -1)
            {
                string query = $"SELECT shift_date, total_revenue FROM shift WHERE shift_id = {currentShiftId}";
                DataTable result = DatabaseConnection.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    DateTime shiftDate = Convert.ToDateTime(result.Rows[0]["shift_date"]);
                    decimal totalRevenue = Convert.ToDecimal(result.Rows[0]["total_revenue"]);

                    lblCurrentShift.Text = $"Текущая смена: #{currentShiftId} от {shiftDate:dd.MM.yyyy} (Выручка: {totalRevenue:C})";
                }
            }
        }

        private void editSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSales.SelectedRows[0].Cells["sale_id"].Value);
                int shiftId = Convert.ToInt32(dgvSales.SelectedRows[0].Cells["shift_id"].Value);

                SaleForm form = new SaleForm(id, shiftId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSales();
                    LoadWarehouse(); // Обновляем данные склада, так как изменились остатки
                    LoadShifts(); // Обновляем данные о сменах, так как изменилась выручка

                    // Обновляем информацию о текущей смене
                    UpdateCurrentShiftInfo();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите продажу для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSales.SelectedRows[0].Cells["sale_id"].Value);
                DateTime saleDate = Convert.ToDateTime(dgvSales.SelectedRows[0].Cells["sale_datetime"].Value);

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить продажу от {saleDate}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Получаем детали продажи для обновления склада и выручки смены
                    string getSaleQuery = $"SELECT product_id, sale_quantity, sale_total, shift_id FROM sale WHERE sale_id = {id}";
                    DataTable saleData = DatabaseConnection.ExecuteQuery(getSaleQuery);

                    if (saleData.Rows.Count > 0)
                    {
                        int productId = Convert.ToInt32(saleData.Rows[0]["product_id"]);
                        int quantity = Convert.ToInt32(saleData.Rows[0]["sale_quantity"]);
                        decimal saleTotal = Convert.ToDecimal(saleData.Rows[0]["sale_total"]);
                        int shiftId = Convert.ToInt32(saleData.Rows[0]["shift_id"]);

                        // Возвращаем товары на склад
                        string updateWarehouseQuery = $@"
                            UPDATE warehouse 
                            SET stock_quantity = stock_quantity + {quantity} 
                            WHERE product_id = {productId}";
                        DatabaseConnection.ExecuteNonQuery(updateWarehouseQuery);

                        // Уменьшаем выручку смены
                        string updateShiftQuery = $@"
                            UPDATE shift 
                            SET total_revenue = total_revenue - {saleTotal} 
                            WHERE shift_id = {shiftId}";
                        DatabaseConnection.ExecuteNonQuery(updateShiftQuery);

                        // Удаляем продажу
                        string deleteSaleQuery = $"DELETE FROM sale WHERE sale_id = {id}";
                        int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteSaleQuery);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Продажа успешно удалена и инвентарь обновлен.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSales();
                            LoadWarehouse();
                            LoadShifts();

                            // Обновляем информацию о текущей смене
                            UpdateCurrentShiftInfo();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите продажу для удаления.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Заказы
        private void addOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, начата ли смена
            if (currentShiftId == -1)
            {
                MessageBox.Show("Пожалуйста, начните смену перед добавлением заказа.", "Требуется смена",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OrderForm form = new OrderForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
                LoadWarehouse(); // Обновляем данные склада, так как изменились остатки
            }
        }

        private void editOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["order_part_id"].Value);

                OrderForm form = new OrderForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                    LoadWarehouse(); // Обновляем данные склада, так как изменились остатки
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["order_part_id"].Value);
                DateTime orderDate = Convert.ToDateTime(dgvOrders.SelectedRows[0].Cells["order_date"].Value);

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить заказ от {orderDate}?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Получаем детали заказа для обновления склада
                    string getOrderQuery = $"SELECT product_id, order_quantity FROM product_order WHERE order_part_id = {id}";
                    DataTable orderData = DatabaseConnection.ExecuteQuery(getOrderQuery);

                    if (orderData.Rows.Count > 0)
                    {
                        int productId = Convert.ToInt32(orderData.Rows[0]["product_id"]);
                        int quantity = Convert.ToInt32(orderData.Rows[0]["order_quantity"]);

                        // Удаляем товары со склада
                        string updateWarehouseQuery = $@"
                            UPDATE warehouse 
                            SET stock_quantity = stock_quantity - {quantity} 
                            WHERE product_id = {productId} AND stock_quantity >= {quantity}";
                        int warehouseUpdated = DatabaseConnection.ExecuteNonQuery(updateWarehouseQuery);

                        if (warehouseUpdated <= 0)
                        {
                            MessageBox.Show("Невозможно удалить заказ, так как это приведет к отрицательному количеству на складе.",
                                "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Удаляем заказ
                        string deleteOrderQuery = $"DELETE FROM product_order WHERE order_part_id = {id}";
                        int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteOrderQuery);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Заказ успешно удален и инвентарь обновлен.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrders();
                            LoadWarehouse();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для удаления.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Должности
        private void addPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PositionForm form = new PositionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPositions();
            }
        }

        private void editPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["position_id"].Value);
                string name = dgvPositions.SelectedRows[0].Cells["position_name"].Value.ToString();

                PositionForm form = new PositionForm(id, name);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPositions();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите должность для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deletePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["position_id"].Value);
                string name = dgvPositions.SelectedRows[0].Cells["position_name"].Value.ToString();

                // Проверяем, есть ли сотрудники с этой должностью
                string checkQuery = $"SELECT COUNT(*) FROM employee WHERE position_id = {id}";
                int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery));

                if (count > 0)
                {
                    MessageBox.Show($"Невозможно удалить должность '{name}', так как она назначена {count} сотрудникам.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить должность '{name}'?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM position WHERE position_id = {id}";
                    int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteQuery);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Должность успешно удалена.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPositions();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите должность для удаления.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Сотрудники
        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm form = new EmployeeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["employee_id"].Value);

                EmployeeForm form = new EmployeeForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["employee_id"].Value);
                string name = dgvEmployees.SelectedRows[0].Cells["full_name"].Value.ToString();

                // Проверяем, есть ли смены у этого сотрудника
                string checkQuery = $"SELECT COUNT(*) FROM shift WHERE employee_id = {id}";
                int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery));

                if (count > 0)
                {
                    MessageBox.Show($"Невозможно удалить сотрудника '{name}', так как у него есть {count} записей о сменах.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника '{name}'?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM employee WHERE employee_id = {id}";
                    int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteQuery);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Сотрудник успешно удален.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Смены
        private void addShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftForm form = new ShiftForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadShifts();
            }
        }

        private void editShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShifts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvShifts.SelectedRows[0].Cells["shift_id"].Value);

                ShiftForm form = new ShiftForm(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadShifts();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите смену для редактирования.", "Нет выбора",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Поиск и фильтрация
        /// <summary>
        /// Общий метод поиска для всех таблиц
        /// </summary>
        private void SearchInDataGridView(DataGridView dgv, string searchTerm, ComboBox filterComboBox)
        {
            if (dgv.DataSource == null) return;

            // Если поисковый запрос пустой, восстанавливаем исходные данные
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Перезагружаем соответствующую таблицу
                if (dgv == dgvEmployees) LoadEmployees();
                else if (dgv == dgvPositions) LoadPositions();
                else if (dgv == dgvProducts) LoadProducts();
                else if (dgv == dgvProductTypes) LoadProductTypes();
                else if (dgv == dgvWarehouse) LoadWarehouse();
                else if (dgv == dgvSales) LoadSales();
                else if (dgv == dgvOrders) LoadOrders();
                else if (dgv == dgvShifts) LoadShifts();
                return;
            }

            // Получаем выбранный столбец для фильтрации
            string selectedColumn = filterComboBox.SelectedItem.ToString();

            // Создаем временную таблицу для фильтрации
            DataTable dt = ((DataTable)dgv.DataSource).Copy();
            DataView dv = dt.DefaultView;

            // Если выбраны все столбцы, ищем по всем текстовым столбцам
            if (selectedColumn == "Все столбцы")
            {
                // Создаем фильтр для поиска по всем столбцам
                string filter = "";
                foreach (DataColumn column in dt.Columns)
                {
                    // Исключаем ID-столбцы и нетекстовые столбцы
                    if (!column.ColumnName.EndsWith("_id") && !column.ColumnName.Equals("id") &&
                        (column.DataType == typeof(string) || column.DataType == typeof(DateTime)))
                    {
                        if (filter.Length > 0) filter += " OR ";
                        filter += $"CONVERT({column.ColumnName}, 'System.String') LIKE '%{searchTerm}%'";
                    }
                }
                dv.RowFilter = filter;
            }
            else
            {
                // Ищем соответствующее имя столбца в DataTable
                string columnName = "";
                foreach (DataColumn column in dt.Columns)
                {
                    if (dgv.Columns[column.ColumnName].HeaderText == selectedColumn)
                    {
                        columnName = column.ColumnName;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(columnName))
                {
                    dv.RowFilter = $"CONVERT({columnName}, 'System.String') LIKE '%{searchTerm}%'";
                }
            }

            // Обновляем источник данных
            dgv.DataSource = dv.ToTable();
        }

        private void txtSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvEmployees, txtSearchEmployees.Text.Trim(), cmbFilterEmployees);
        }

        private void txtSearchPositions_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvPositions, txtSearchPositions.Text.Trim(), cmbFilterPositions);
        }

        private void txtSearchProducts_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvProducts, txtSearchProducts.Text.Trim(), cmbFilterProducts);
        }

        private void txtSearchProductTypes_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvProductTypes, txtSearchProductTypes.Text.Trim(), cmbFilterProductTypes);
        }

        private void txtSearchWarehouse_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvWarehouse, txtSearchWarehouse.Text.Trim(), cmbFilterWarehouse);
        }

        private void txtSearchSales_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvSales, txtSearchSales.Text.Trim(), cmbFilterSales);
        }

        private void txtSearchOrders_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvOrders, txtSearchOrders.Text.Trim(), cmbFilterOrders);
        }

        private void txtSearchShifts_TextChanged(object sender, EventArgs e)
        {
            SearchInDataGridView(dgvShifts, txtSearchShifts.Text.Trim(), cmbFilterShifts);
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // Конец выбранного дня

            string reportType = cmbReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Пожалуйста, выберите тип отчета.", "Ошибка отчета",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "";

            switch (reportType)
            {
                case "Отчет по продажам":
                    query = $@"SELECT s.sale_datetime::date as date, 
                             COUNT(*) as total_sales, 
                             SUM(s.sale_quantity) as total_items_sold,
                             SUM(s.sale_total) as total_revenue
                             FROM sale s
                             WHERE s.sale_datetime BETWEEN '{startDate}' AND '{endDate}'
                             GROUP BY s.sale_datetime::date
                             ORDER BY s.sale_datetime::date";
                    break;

                case "Отчет по заказам":
                    query = $@"SELECT o.order_date as date, 
                             COUNT(*) as total_orders, 
                             SUM(o.order_quantity) as total_items_ordered,
                             SUM(o.order_total) as total_cost
                             FROM product_order o
                             WHERE o.order_date BETWEEN '{startDate}' AND '{endDate}'
                             GROUP BY o.order_date
                             ORDER BY o.order_date";
                    break;

                case "Отчет по складу":
                    query = $@"SELECT p.product_type_id, pt.product_type_name, 
                             COUNT(*) as product_count,
                             SUM(w.stock_quantity) as total_stock
                             FROM product p
                             JOIN product_type pt ON p.product_type_id = pt.product_type_id
                             JOIN warehouse w ON p.product_id = w.product_id
                             GROUP BY p.product_type_id, pt.product_type_name
                             ORDER BY pt.product_type_name";
                    break;
            }

            dgvReports.DataSource = DatabaseConnection.ExecuteQuery(query);
        }
        #endregion
    }
}