using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class ShiftForm : Form
    {
        private int shiftId = 0;
        private bool isEditing = false;

        /// <summary>
        /// Конструктор для создания новой смены
        /// </summary>
        public ShiftForm()
        {
            InitializeComponent();
            this.Text = "Добавить смену";

            // Загружаем список сотрудников
            LoadEmployees();

            // Устанавливаем текущую дату
            dtpShiftDate.Value = DateTime.Now;

            // Устанавливаем начальную выручку 0 и делаем поле недоступным
            txtTotalRevenue.Text = "0";
            txtTotalRevenue.ReadOnly = true;
        }

        /// <summary>
        /// Конструктор для редактирования существующей смены
        /// </summary>
        /// <param name="id">ID смены</param>
        public ShiftForm(int id)
        {
            InitializeComponent();
            this.Text = "Изменить смену";
            this.shiftId = id;
            this.isEditing = true;

            // Загружаем список сотрудников
            LoadEmployees();

            // Загружаем данные смены
            LoadShiftData();

            // Делаем поле выручки недоступным для редактирования
            txtTotalRevenue.ReadOnly = true;

            // Делаем поле даты недоступным для редактирования
            dtpShiftDate.Enabled = false;
        }

        /// <summary>
        /// Загрузка списка сотрудников для комбобокса
        /// </summary>
        private void LoadEmployees()
        {
            string query = @"SELECT employee_id, full_name FROM employee ORDER BY full_name";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbEmployee.DataSource = dt;
            cmbEmployee.DisplayMember = "full_name";
            cmbEmployee.ValueMember = "employee_id";
        }

        /// <summary>
        /// Загрузка данных смены для редактирования
        /// </summary>
        private void LoadShiftData()
        {
            string query = $"SELECT * FROM shift WHERE shift_id = {shiftId}";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Устанавливаем значения полей
                dtpShiftDate.Value = Convert.ToDateTime(row["shift_date"]);
                cmbEmployee.SelectedValue = row["employee_id"];
                txtTotalRevenue.Text = row["total_revenue"].ToString();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли сотрудник
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            DateTime shiftDate = dtpShiftDate.Value.Date;
            decimal totalRevenue = Convert.ToDecimal(txtTotalRevenue.Text);

            try
            {
                string query;

                if (isEditing)
                {
                    // Обновляем существующую смену
                    query = $@"UPDATE shift 
                             SET employee_id = {employeeId} 
                             WHERE shift_id = {shiftId}";
                }
                else
                {
                    // Добавляем новую смену
                    query = $@"INSERT INTO shift 
                             (shift_date, employee_id, total_revenue) 
                             VALUES 
                             ('{shiftDate:yyyy-MM-dd}', {employeeId}, {totalRevenue.ToString().Replace(",", ".")})";
                }

                int result = DatabaseConnection.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Смена успешно сохранена.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить смену.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении смены: " + ex.Message, "Ошибка",
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