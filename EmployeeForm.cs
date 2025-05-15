using System;
using System.Data;
using System.Windows.Forms;

namespace MusicStoreWarehouse
{
    public partial class EmployeeForm : Form
    {
        private int employeeId = 0;
        private bool isEditing = false;

        /// <summary>
        /// Конструктор для создания нового сотрудника
        /// </summary>
        public EmployeeForm()
        {
            InitializeComponent();
            this.Text = "Добавить сотрудника";

            // Загружаем список должностей
            LoadPositions();

            // Устанавливаем текущую дату
            dtpHireDate.Value = DateTime.Now;

            // Скрываем чекбокс сброса пароля для нового сотрудника
            chkResetPassword.Visible = false;
        }

        /// <summary>
        /// Конструктор для редактирования существующего сотрудника
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        public EmployeeForm(int id)
        {
            InitializeComponent();
            this.Text = "Изменить сотрудника";
            this.employeeId = id;
            this.isEditing = true;

            // Загружаем список должностей
            LoadPositions();

            // Загружаем данные сотрудника
            LoadEmployeeData();

            // Показываем чекбокс сброса пароля
            chkResetPassword.Visible = true;

            // Если выбран сброс пароля, очищаем поле пароля
            chkResetPassword.CheckedChanged += (s, e) => {
                txtPassword.Enabled = chkResetPassword.Checked;
                if (chkResetPassword.Checked)
                {
                    txtPassword.Text = "";
                }
                else
                {
                    txtPassword.Text = "********";
                }
            };

            // По умолчанию отключаем поле пароля
            txtPassword.Text = "********";
            txtPassword.Enabled = false;
        }

        /// <summary>
        /// Загрузка списка должностей для комбобокса
        /// </summary>
        private void LoadPositions()
        {
            string query = "SELECT position_id, position_name FROM position ORDER BY position_name";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbPosition.DataSource = dt;
            cmbPosition.DisplayMember = "position_name";
            cmbPosition.ValueMember = "position_id";
        }

        /// <summary>
        /// Загрузка данных сотрудника для редактирования
        /// </summary>
        private void LoadEmployeeData()
        {
            string query = $"SELECT * FROM employee WHERE employee_id = {employeeId}";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Устанавливаем значения полей
                txtFullName.Text = row["full_name"].ToString();
                txtContactNumber.Text = row["contact_number"].ToString();
                cmbPosition.SelectedValue = row["position_id"];
                dtpHireDate.Value = Convert.ToDateTime(row["hire_date"]);
                txtLogin.Text = row["login"].ToString();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных полей
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста, введите ФИО сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtContactNumber.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста, введите контактный номер сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите должность сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtLogin.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста, введите логин сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isEditing && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Пожалуйста, введите пароль сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditing && chkResetPassword.Checked && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Пожалуйста, введите новый пароль сотрудника.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            int positionId = Convert.ToInt32(cmbPosition.SelectedValue);
            DateTime hireDate = dtpHireDate.Value.Date;
            string login = txtLogin.Text.Trim();

            try
            {
                // Проверяем уникальность логина
                string checkLoginQuery = $"SELECT COUNT(*) FROM employee WHERE login = '{login}'";
                if (isEditing)
                {
                    checkLoginQuery += $" AND employee_id != {employeeId}";
                }

                int loginCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkLoginQuery));
                if (loginCount > 0)
                {
                    MessageBox.Show($"Логин '{login}' уже используется. Пожалуйста, выберите другой логин.",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query;

                if (isEditing)
                {
                    // Обновляем существующего сотрудника
                    query = $@"UPDATE employee 
                             SET full_name = '{fullName}', 
                             contact_number = '{contactNumber}', 
                             position_id = {positionId}, 
                             hire_date = '{hireDate:yyyy-MM-dd}', 
                             login = '{login}'";

                    // Если выбран сброс пароля, обновляем пароль
                    if (chkResetPassword.Checked)
                    {
                        string passwordHash = LoginForm.HashPassword(txtPassword.Text);
                        query += $", password_hash = '{passwordHash}'";
                    }

                    query += $" WHERE employee_id = {employeeId}";
                }
                else
                {
                    // Добавляем нового сотрудника
                    string passwordHash = LoginForm.HashPassword(txtPassword.Text);

                    query = $@"INSERT INTO employee 
                             (full_name, contact_number, position_id, hire_date, login, password_hash) 
                             VALUES 
                             ('{fullName}', '{contactNumber}', {positionId}, '{hireDate:yyyy-MM-dd}', '{login}', '{passwordHash}')";
                }

                int result = DatabaseConnection.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Сотрудник успешно сохранен.", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить сотрудника.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении сотрудника: " + ex.Message, "Ошибка",
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