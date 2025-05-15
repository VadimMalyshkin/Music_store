namespace MusicStoreWarehouse
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblCurrentShift = new System.Windows.Forms.Label();
            this.btnStartShift = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnShifts = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnProductTypes = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnPositions = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.cmbFilterEmployees = new System.Windows.Forms.ComboBox();
            this.lblFilterEmployees = new System.Windows.Forms.Label();
            this.txtSearchEmployees = new System.Windows.Forms.TextBox();
            this.lblSearchEmployees = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.tabPositions = new System.Windows.Forms.TabPage();
            this.cmbFilterPositions = new System.Windows.Forms.ComboBox();
            this.lblFilterPositions = new System.Windows.Forms.Label();
            this.txtSearchPositions = new System.Windows.Forms.TextBox();
            this.lblSearchPositions = new System.Windows.Forms.Label();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.cmbFilterProducts = new System.Windows.Forms.ComboBox();
            this.lblFilterProducts = new System.Windows.Forms.Label();
            this.txtSearchProducts = new System.Windows.Forms.TextBox();
            this.lblSearchProducts = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tabProductTypes = new System.Windows.Forms.TabPage();
            this.cmbFilterProductTypes = new System.Windows.Forms.ComboBox();
            this.lblFilterProductTypes = new System.Windows.Forms.Label();
            this.txtSearchProductTypes = new System.Windows.Forms.TextBox();
            this.lblSearchProductTypes = new System.Windows.Forms.Label();
            this.dgvProductTypes = new System.Windows.Forms.DataGridView();
            this.tabWarehouse = new System.Windows.Forms.TabPage();
            this.cmbFilterWarehouse = new System.Windows.Forms.ComboBox();
            this.lblFilterWarehouse = new System.Windows.Forms.Label();
            this.txtSearchWarehouse = new System.Windows.Forms.TextBox();
            this.lblSearchWarehouse = new System.Windows.Forms.Label();
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.cmbFilterSales = new System.Windows.Forms.ComboBox();
            this.lblFilterSales = new System.Windows.Forms.Label();
            this.txtSearchSales = new System.Windows.Forms.TextBox();
            this.lblSearchSales = new System.Windows.Forms.Label();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.cmbFilterOrders = new System.Windows.Forms.ComboBox();
            this.lblFilterOrders = new System.Windows.Forms.Label();
            this.txtSearchOrders = new System.Windows.Forms.TextBox();
            this.lblSearchOrders = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.tabShifts = new System.Windows.Forms.TabPage();
            this.cmbFilterShifts = new System.Windows.Forms.ComboBox();
            this.lblFilterShifts = new System.Windows.Forms.Label();
            this.txtSearchShifts = new System.Windows.Forms.TextBox();
            this.lblSearchShifts = new System.Windows.Forms.Label();
            this.dgvShifts = new System.Windows.Forms.DataGridView();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.cmEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPositions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmProductTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addProductTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProductTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWarehouse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addWarehouseItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editWarehouseItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSales = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmShifts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.tabPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabProductTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTypes)).BeginInit();
            this.tabWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tabShifts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).BeginInit();
            this.tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.cmEmployees.SuspendLayout();
            this.cmPositions.SuspendLayout();
            this.cmProducts.SuspendLayout();
            this.cmProductTypes.SuspendLayout();
            this.cmWarehouse.SuspendLayout();
            this.cmSales.SuspendLayout();
            this.cmOrders.SuspendLayout();
            this.cmShifts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelTop.Controls.Add(this.lblCurrentShift);
            this.panelTop.Controls.Add(this.btnStartShift);
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.btnReports);
            this.panelTop.Controls.Add(this.btnShifts);
            this.panelTop.Controls.Add(this.btnOrders);
            this.panelTop.Controls.Add(this.btnSales);
            this.panelTop.Controls.Add(this.btnWarehouse);
            this.panelTop.Controls.Add(this.btnProductTypes);
            this.panelTop.Controls.Add(this.btnProducts);
            this.panelTop.Controls.Add(this.btnPositions);
            this.panelTop.Controls.Add(this.btnEmployees);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1024, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblCurrentShift
            // 
            this.lblCurrentShift.AutoSize = true;
            this.lblCurrentShift.Location = new System.Drawing.Point(370, 40);
            this.lblCurrentShift.Name = "lblCurrentShift";
            this.lblCurrentShift.Size = new System.Drawing.Size(89, 13);
            this.lblCurrentShift.TabIndex = 12;
            this.lblCurrentShift.Text = "Текущая смена:";
            // 
            // btnStartShift
            // 
            this.btnStartShift.Location = new System.Drawing.Point(289, 35);
            this.btnStartShift.Name = "btnStartShift";
            this.btnStartShift.Size = new System.Drawing.Size(75, 23);
            this.btnStartShift.TabIndex = 11;
            this.btnStartShift.Text = "Начать смену";
            this.btnStartShift.UseVisualStyleBackColor = true;
            this.btnStartShift.Click += new System.EventHandler(this.btnStartShift_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(937, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Выход";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(856, 12);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(75, 23);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Отчеты";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnShifts
            // 
            this.btnShifts.Location = new System.Drawing.Point(775, 12);
            this.btnShifts.Name = "btnShifts";
            this.btnShifts.Size = new System.Drawing.Size(75, 23);
            this.btnShifts.TabIndex = 8;
            this.btnShifts.Text = "Смены";
            this.btnShifts.UseVisualStyleBackColor = true;
            this.btnShifts.Click += new System.EventHandler(this.btnShifts_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(694, 12);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(75, 23);
            this.btnOrders.TabIndex = 7;
            this.btnOrders.Text = "Заказы";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnSales
            // 
            this.btnSales.Location = new System.Drawing.Point(613, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(75, 23);
            this.btnSales.TabIndex = 6;
            this.btnSales.Text = "Продажи";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Location = new System.Drawing.Point(532, 12);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(75, 23);
            this.btnWarehouse.TabIndex = 5;
            this.btnWarehouse.Text = "Склад";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnProductTypes
            // 
            this.btnProductTypes.Location = new System.Drawing.Point(451, 12);
            this.btnProductTypes.Name = "btnProductTypes";
            this.btnProductTypes.Size = new System.Drawing.Size(75, 23);
            this.btnProductTypes.TabIndex = 4;
            this.btnProductTypes.Text = "Типы тов.";
            this.btnProductTypes.UseVisualStyleBackColor = true;
            this.btnProductTypes.Click += new System.EventHandler(this.btnProductTypes_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(370, 12);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(75, 23);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "Товары";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnPositions
            // 
            this.btnPositions.Location = new System.Drawing.Point(289, 12);
            this.btnPositions.Name = "btnPositions";
            this.btnPositions.Size = new System.Drawing.Size(75, 23);
            this.btnPositions.TabIndex = 2;
            this.btnPositions.Text = "Должности";
            this.btnPositions.UseVisualStyleBackColor = true;
            this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(208, 12);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(75, 23);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Сотрудники";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Склад муз. магазина";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEmployees);
            this.tabControl.Controls.Add(this.tabPositions);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabProductTypes);
            this.tabControl.Controls.Add(this.tabWarehouse);
            this.tabControl.Controls.Add(this.tabSales);
            this.tabControl.Controls.Add(this.tabOrders);
            this.tabControl.Controls.Add(this.tabShifts);
            this.tabControl.Controls.Add(this.tabReports);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1024, 508);
            this.tabControl.TabIndex = 1;
            // 
            // tabEmployees
            // 
            this.tabEmployees.Controls.Add(this.cmbFilterEmployees);
            this.tabEmployees.Controls.Add(this.lblFilterEmployees);
            this.tabEmployees.Controls.Add(this.txtSearchEmployees);
            this.tabEmployees.Controls.Add(this.lblSearchEmployees);
            this.tabEmployees.Controls.Add(this.dgvEmployees);
            this.tabEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(1016, 482);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Сотрудники";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // cmbFilterEmployees
            // 
            this.cmbFilterEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterEmployees.FormattingEnabled = true;
            this.cmbFilterEmployees.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterEmployees.Name = "cmbFilterEmployees";
            this.cmbFilterEmployees.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterEmployees.TabIndex = 4;
            // 
            // lblFilterEmployees
            // 
            this.lblFilterEmployees.AutoSize = true;
            this.lblFilterEmployees.Location = new System.Drawing.Point(290, 9);
            this.lblFilterEmployees.Name = "lblFilterEmployees";
            this.lblFilterEmployees.Size = new System.Drawing.Size(94, 13);
            this.lblFilterEmployees.TabIndex = 3;
            this.lblFilterEmployees.Text = "Фильтровать по:";
            // 
            // txtSearchEmployees
            // 
            this.txtSearchEmployees.Location = new System.Drawing.Point(84, 6);
            this.txtSearchEmployees.Name = "txtSearchEmployees";
            this.txtSearchEmployees.Size = new System.Drawing.Size(200, 20);
            this.txtSearchEmployees.TabIndex = 2;
            this.txtSearchEmployees.TextChanged += new System.EventHandler(this.txtSearchEmployees_TextChanged);
            // 
            // lblSearchEmployees
            // 
            this.lblSearchEmployees.AutoSize = true;
            this.lblSearchEmployees.Location = new System.Drawing.Point(6, 9);
            this.lblSearchEmployees.Name = "lblSearchEmployees";
            this.lblSearchEmployees.Size = new System.Drawing.Size(72, 13);
            this.lblSearchEmployees.TabIndex = 1;
            this.lblSearchEmployees.Text = "Поиск:";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(3, 32);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(1010, 447);
            this.dgvEmployees.TabIndex = 0;
            // 
            // tabPositions
            // 
            this.tabPositions.Controls.Add(this.cmbFilterPositions);
            this.tabPositions.Controls.Add(this.lblFilterPositions);
            this.tabPositions.Controls.Add(this.txtSearchPositions);
            this.tabPositions.Controls.Add(this.lblSearchPositions);
            this.tabPositions.Controls.Add(this.dgvPositions);
            this.tabPositions.Location = new System.Drawing.Point(4, 22);
            this.tabPositions.Name = "tabPositions";
            this.tabPositions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPositions.Size = new System.Drawing.Size(1016, 482);
            this.tabPositions.TabIndex = 1;
            this.tabPositions.Text = "Должности";
            this.tabPositions.UseVisualStyleBackColor = true;
            // 
            // cmbFilterPositions
            // 
            this.cmbFilterPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterPositions.FormattingEnabled = true;
            this.cmbFilterPositions.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterPositions.Name = "cmbFilterPositions";
            this.cmbFilterPositions.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterPositions.TabIndex = 8;
            // 
            // lblFilterPositions
            // 
            this.lblFilterPositions.AutoSize = true;
            this.lblFilterPositions.Location = new System.Drawing.Point(290, 9);
            this.lblFilterPositions.Name = "lblFilterPositions";
            this.lblFilterPositions.Size = new System.Drawing.Size(94, 13);
            this.lblFilterPositions.TabIndex = 7;
            this.lblFilterPositions.Text = "Фильтровать по:";
            // 
            // txtSearchPositions
            // 
            this.txtSearchPositions.Location = new System.Drawing.Point(84, 6);
            this.txtSearchPositions.Name = "txtSearchPositions";
            this.txtSearchPositions.Size = new System.Drawing.Size(200, 20);
            this.txtSearchPositions.TabIndex = 6;
            this.txtSearchPositions.TextChanged += new System.EventHandler(this.txtSearchPositions_TextChanged);
            // 
            // lblSearchPositions
            // 
            this.lblSearchPositions.AutoSize = true;
            this.lblSearchPositions.Location = new System.Drawing.Point(6, 9);
            this.lblSearchPositions.Name = "lblSearchPositions";
            this.lblSearchPositions.Size = new System.Drawing.Size(72, 13);
            this.lblSearchPositions.TabIndex = 5;
            this.lblSearchPositions.Text = "Поиск:";
            // 
            // dgvPositions
            // 
            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AllowUserToDeleteRows = false;
            this.dgvPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Location = new System.Drawing.Point(3, 32);
            this.dgvPositions.MultiSelect = false;
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.ReadOnly = true;
            this.dgvPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPositions.Size = new System.Drawing.Size(1010, 447);
            this.dgvPositions.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.cmbFilterProducts);
            this.tabProducts.Controls.Add(this.lblFilterProducts);
            this.tabProducts.Controls.Add(this.txtSearchProducts);
            this.tabProducts.Controls.Add(this.lblSearchProducts);
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(1016, 482);
            this.tabProducts.TabIndex = 2;
            this.tabProducts.Text = "Товары";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // cmbFilterProducts
            // 
            this.cmbFilterProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterProducts.FormattingEnabled = true;
            this.cmbFilterProducts.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterProducts.Name = "cmbFilterProducts";
            this.cmbFilterProducts.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterProducts.TabIndex = 8;
            // 
            // lblFilterProducts
            // 
            this.lblFilterProducts.AutoSize = true;
            this.lblFilterProducts.Location = new System.Drawing.Point(290, 9);
            this.lblFilterProducts.Name = "lblFilterProducts";
            this.lblFilterProducts.Size = new System.Drawing.Size(94, 13);
            this.lblFilterProducts.TabIndex = 7;
            this.lblFilterProducts.Text = "Фильтровать по:";
            // 
            // txtSearchProducts
            // 
            this.txtSearchProducts.Location = new System.Drawing.Point(84, 6);
            this.txtSearchProducts.Name = "txtSearchProducts";
            this.txtSearchProducts.Size = new System.Drawing.Size(200, 20);
            this.txtSearchProducts.TabIndex = 2;
            this.txtSearchProducts.TextChanged += new System.EventHandler(this.txtSearchProducts_TextChanged);
            // 
            // lblSearchProducts
            // 
            this.lblSearchProducts.AutoSize = true;
            this.lblSearchProducts.Location = new System.Drawing.Point(6, 9);
            this.lblSearchProducts.Name = "lblSearchProducts";
            this.lblSearchProducts.Size = new System.Drawing.Size(72, 13);
            this.lblSearchProducts.TabIndex = 1;
            this.lblSearchProducts.Text = "Поиск:";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(3, 32);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1010, 447);
            this.dgvProducts.TabIndex = 0;
            // 
            // tabProductTypes
            // 
            this.tabProductTypes.Controls.Add(this.cmbFilterProductTypes);
            this.tabProductTypes.Controls.Add(this.lblFilterProductTypes);
            this.tabProductTypes.Controls.Add(this.txtSearchProductTypes);
            this.tabProductTypes.Controls.Add(this.lblSearchProductTypes);
            this.tabProductTypes.Controls.Add(this.dgvProductTypes);
            this.tabProductTypes.Location = new System.Drawing.Point(4, 22);
            this.tabProductTypes.Name = "tabProductTypes";
            this.tabProductTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductTypes.Size = new System.Drawing.Size(1016, 482);
            this.tabProductTypes.TabIndex = 3;
            this.tabProductTypes.Text = "Типы товаров";
            this.tabProductTypes.UseVisualStyleBackColor = true;
            // 
            // cmbFilterProductTypes
            // 
            this.cmbFilterProductTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterProductTypes.FormattingEnabled = true;
            this.cmbFilterProductTypes.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterProductTypes.Name = "cmbFilterProductTypes";
            this.cmbFilterProductTypes.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterProductTypes.TabIndex = 8;
            // 
            // lblFilterProductTypes
            // 
            this.lblFilterProductTypes.AutoSize = true;
            this.lblFilterProductTypes.Location = new System.Drawing.Point(290, 9);
            this.lblFilterProductTypes.Name = "lblFilterProductTypes";
            this.lblFilterProductTypes.Size = new System.Drawing.Size(94, 13);
            this.lblFilterProductTypes.TabIndex = 7;
            this.lblFilterProductTypes.Text = "Фильтровать по:";
            // 
            // txtSearchProductTypes
            // 
            this.txtSearchProductTypes.Location = new System.Drawing.Point(84, 6);
            this.txtSearchProductTypes.Name = "txtSearchProductTypes";
            this.txtSearchProductTypes.Size = new System.Drawing.Size(200, 20);
            this.txtSearchProductTypes.TabIndex = 6;
            this.txtSearchProductTypes.TextChanged += new System.EventHandler(this.txtSearchProductTypes_TextChanged);
            // 
            // lblSearchProductTypes
            // 
            this.lblSearchProductTypes.AutoSize = true;
            this.lblSearchProductTypes.Location = new System.Drawing.Point(6, 9);
            this.lblSearchProductTypes.Name = "lblSearchProductTypes";
            this.lblSearchProductTypes.Size = new System.Drawing.Size(72, 13);
            this.lblSearchProductTypes.TabIndex = 5;
            this.lblSearchProductTypes.Text = "Поиск:";
            // 
            // dgvProductTypes
            // 
            this.dgvProductTypes.AllowUserToAddRows = false;
            this.dgvProductTypes.AllowUserToDeleteRows = false;
            this.dgvProductTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductTypes.Location = new System.Drawing.Point(3, 32);
            this.dgvProductTypes.MultiSelect = false;
            this.dgvProductTypes.Name = "dgvProductTypes";
            this.dgvProductTypes.ReadOnly = true;
            this.dgvProductTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductTypes.Size = new System.Drawing.Size(1010, 447);
            this.dgvProductTypes.TabIndex = 0;
            // 
            // tabWarehouse
            // 
            this.tabWarehouse.Controls.Add(this.cmbFilterWarehouse);
            this.tabWarehouse.Controls.Add(this.lblFilterWarehouse);
            this.tabWarehouse.Controls.Add(this.txtSearchWarehouse);
            this.tabWarehouse.Controls.Add(this.lblSearchWarehouse);
            this.tabWarehouse.Controls.Add(this.dgvWarehouse);
            this.tabWarehouse.Location = new System.Drawing.Point(4, 22);
            this.tabWarehouse.Name = "tabWarehouse";
            this.tabWarehouse.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarehouse.Size = new System.Drawing.Size(1016, 482);
            this.tabWarehouse.TabIndex = 4;
            this.tabWarehouse.Text = "Склад";
            this.tabWarehouse.UseVisualStyleBackColor = true;
            // 
            // cmbFilterWarehouse
            // 
            this.cmbFilterWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterWarehouse.FormattingEnabled = true;
            this.cmbFilterWarehouse.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterWarehouse.Name = "cmbFilterWarehouse";
            this.cmbFilterWarehouse.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterWarehouse.TabIndex = 8;
            // 
            // lblFilterWarehouse
            // 
            this.lblFilterWarehouse.AutoSize = true;
            this.lblFilterWarehouse.Location = new System.Drawing.Point(290, 9);
            this.lblFilterWarehouse.Name = "lblFilterWarehouse";
            this.lblFilterWarehouse.Size = new System.Drawing.Size(94, 13);
            this.lblFilterWarehouse.TabIndex = 7;
            this.lblFilterWarehouse.Text = "Фильтровать по:";
            // 
            // txtSearchWarehouse
            // 
            this.txtSearchWarehouse.Location = new System.Drawing.Point(84, 6);
            this.txtSearchWarehouse.Name = "txtSearchWarehouse";
            this.txtSearchWarehouse.Size = new System.Drawing.Size(200, 20);
            this.txtSearchWarehouse.TabIndex = 4;
            this.txtSearchWarehouse.TextChanged += new System.EventHandler(this.txtSearchWarehouse_TextChanged);
            // 
            // lblSearchWarehouse
            // 
            this.lblSearchWarehouse.AutoSize = true;
            this.lblSearchWarehouse.Location = new System.Drawing.Point(6, 9);
            this.lblSearchWarehouse.Name = "lblSearchWarehouse";
            this.lblSearchWarehouse.Size = new System.Drawing.Size(72, 13);
            this.lblSearchWarehouse.TabIndex = 3;
            this.lblSearchWarehouse.Text = "Поиск:";
            // 
            // dgvWarehouse
            // 
            this.dgvWarehouse.AllowUserToAddRows = false;
            this.dgvWarehouse.AllowUserToDeleteRows = false;
            this.dgvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouse.Location = new System.Drawing.Point(3, 32);
            this.dgvWarehouse.MultiSelect = false;
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.ReadOnly = true;
            this.dgvWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouse.Size = new System.Drawing.Size(1010, 447);
            this.dgvWarehouse.TabIndex = 0;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.cmbFilterSales);
            this.tabSales.Controls.Add(this.lblFilterSales);
            this.tabSales.Controls.Add(this.txtSearchSales);
            this.tabSales.Controls.Add(this.lblSearchSales);
            this.tabSales.Controls.Add(this.dgvSales);
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(1016, 482);
            this.tabSales.TabIndex = 5;
            this.tabSales.Text = "Продажи";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // cmbFilterSales
            // 
            this.cmbFilterSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSales.FormattingEnabled = true;
            this.cmbFilterSales.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterSales.Name = "cmbFilterSales";
            this.cmbFilterSales.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterSales.TabIndex = 8;
            // 
            // lblFilterSales
            // 
            this.lblFilterSales.AutoSize = true;
            this.lblFilterSales.Location = new System.Drawing.Point(290, 9);
            this.lblFilterSales.Name = "lblFilterSales";
            this.lblFilterSales.Size = new System.Drawing.Size(94, 13);
            this.lblFilterSales.TabIndex = 7;
            this.lblFilterSales.Text = "Фильтровать по:";
            // 
            // txtSearchSales
            // 
            this.txtSearchSales.Location = new System.Drawing.Point(84, 6);
            this.txtSearchSales.Name = "txtSearchSales";
            this.txtSearchSales.Size = new System.Drawing.Size(200, 20);
            this.txtSearchSales.TabIndex = 6;
            this.txtSearchSales.TextChanged += new System.EventHandler(this.txtSearchSales_TextChanged);
            // 
            // lblSearchSales
            // 
            this.lblSearchSales.AutoSize = true;
            this.lblSearchSales.Location = new System.Drawing.Point(6, 9);
            this.lblSearchSales.Name = "lblSearchSales";
            this.lblSearchSales.Size = new System.Drawing.Size(72, 13);
            this.lblSearchSales.TabIndex = 5;
            this.lblSearchSales.Text = "Поиск:";
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Location = new System.Drawing.Point(3, 32);
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(1010, 447);
            this.dgvSales.TabIndex = 0;
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.cmbFilterOrders);
            this.tabOrders.Controls.Add(this.lblFilterOrders);
            this.tabOrders.Controls.Add(this.txtSearchOrders);
            this.tabOrders.Controls.Add(this.lblSearchOrders);
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 22);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(1016, 482);
            this.tabOrders.TabIndex = 6;
            this.tabOrders.Text = "Заказы";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // cmbFilterOrders
            // 
            this.cmbFilterOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOrders.FormattingEnabled = true;
            this.cmbFilterOrders.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterOrders.Name = "cmbFilterOrders";
            this.cmbFilterOrders.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterOrders.TabIndex = 8;
            // 
            // lblFilterOrders
            // 
            this.lblFilterOrders.AutoSize = true;
            this.lblFilterOrders.Location = new System.Drawing.Point(290, 9);
            this.lblFilterOrders.Name = "lblFilterOrders";
            this.lblFilterOrders.Size = new System.Drawing.Size(94, 13);
            this.lblFilterOrders.TabIndex = 7;
            this.lblFilterOrders.Text = "Фильтровать по:";
            // 
            // txtSearchOrders
            // 
            this.txtSearchOrders.Location = new System.Drawing.Point(84, 6);
            this.txtSearchOrders.Name = "txtSearchOrders";
            this.txtSearchOrders.Size = new System.Drawing.Size(200, 20);
            this.txtSearchOrders.TabIndex = 6;
            this.txtSearchOrders.TextChanged += new System.EventHandler(this.txtSearchOrders_TextChanged);
            // 
            // lblSearchOrders
            // 
            this.lblSearchOrders.AutoSize = true;
            this.lblSearchOrders.Location = new System.Drawing.Point(6, 9);
            this.lblSearchOrders.Name = "lblSearchOrders";
            this.lblSearchOrders.Size = new System.Drawing.Size(72, 13);
            this.lblSearchOrders.TabIndex = 5;
            this.lblSearchOrders.Text = "Поиск:";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(3, 32);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1010, 447);
            this.dgvOrders.TabIndex = 0;
            // 
            // tabShifts
            // 
            this.tabShifts.Controls.Add(this.cmbFilterShifts);
            this.tabShifts.Controls.Add(this.lblFilterShifts);
            this.tabShifts.Controls.Add(this.txtSearchShifts);
            this.tabShifts.Controls.Add(this.lblSearchShifts);
            this.tabShifts.Controls.Add(this.dgvShifts);
            this.tabShifts.Location = new System.Drawing.Point(4, 22);
            this.tabShifts.Name = "tabShifts";
            this.tabShifts.Padding = new System.Windows.Forms.Padding(3);
            this.tabShifts.Size = new System.Drawing.Size(1016, 482);
            this.tabShifts.TabIndex = 7;
            this.tabShifts.Text = "Смены";
            this.tabShifts.UseVisualStyleBackColor = true;
            // 
            // cmbFilterShifts
            // 
            this.cmbFilterShifts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterShifts.FormattingEnabled = true;
            this.cmbFilterShifts.Location = new System.Drawing.Point(390, 6);
            this.cmbFilterShifts.Name = "cmbFilterShifts";
            this.cmbFilterShifts.Size = new System.Drawing.Size(150, 21);
            this.cmbFilterShifts.TabIndex = 8;
            // 
            // lblFilterShifts
            // 
            this.lblFilterShifts.AutoSize = true;
            this.lblFilterShifts.Location = new System.Drawing.Point(290, 9);
            this.lblFilterShifts.Name = "lblFilterShifts";
            this.lblFilterShifts.Size = new System.Drawing.Size(94, 13);
            this.lblFilterShifts.TabIndex = 7;
            this.lblFilterShifts.Text = "Фильтровать по:";
            // 
            // txtSearchShifts
            // 
            this.txtSearchShifts.Location = new System.Drawing.Point(84, 6);
            this.txtSearchShifts.Name = "txtSearchShifts";
            this.txtSearchShifts.Size = new System.Drawing.Size(200, 20);
            this.txtSearchShifts.TabIndex = 6;
            this.txtSearchShifts.TextChanged += new System.EventHandler(this.txtSearchShifts_TextChanged);
            // 
            // lblSearchShifts
            // 
            this.lblSearchShifts.AutoSize = true;
            this.lblSearchShifts.Location = new System.Drawing.Point(6, 9);
            this.lblSearchShifts.Name = "lblSearchShifts";
            this.lblSearchShifts.Size = new System.Drawing.Size(72, 13);
            this.lblSearchShifts.TabIndex = 5;
            this.lblSearchShifts.Text = "Поиск:";
            // 
            // dgvShifts
            // 
            this.dgvShifts.AllowUserToAddRows = false;
            this.dgvShifts.AllowUserToDeleteRows = false;
            this.dgvShifts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShifts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShifts.Location = new System.Drawing.Point(3, 32);
            this.dgvShifts.MultiSelect = false;
            this.dgvShifts.Name = "dgvShifts";
            this.dgvShifts.ReadOnly = true;
            this.dgvShifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShifts.Size = new System.Drawing.Size(1010, 447);
            this.dgvShifts.TabIndex = 0;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.btnGenerateReport);
            this.tabReports.Controls.Add(this.cmbReportType);
            this.tabReports.Controls.Add(this.lblReportType);
            this.tabReports.Controls.Add(this.dtpEndDate);
            this.tabReports.Controls.Add(this.lblEndDate);
            this.tabReports.Controls.Add(this.dtpStartDate);
            this.tabReports.Controls.Add(this.lblStartDate);
            this.tabReports.Controls.Add(this.dgvReports);
            this.tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1016, 482);
            this.tabReports.TabIndex = 8;
            this.tabReports.Text = "Отчеты";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(650, 6);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateReport.TabIndex = 7;
            this.btnGenerateReport.Text = "Создать отчет";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Отчет по продажам",
            "Отчет по заказам",
            "Отчет по складу"});
            this.cmbReportType.Location = new System.Drawing.Point(523, 8);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(121, 21);
            this.cmbReportType.TabIndex = 6;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(450, 11);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(67, 13);
            this.lblReportType.TabIndex = 5;
            this.lblReportType.Text = "Тип отчета:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(344, 8);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(286, 11);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Дата до:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(180, 8);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(119, 11);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Дата от:";
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(3, 35);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(1010, 444);
            this.dgvReports.TabIndex = 0;
            // 
            // cmEmployees
            // 
            this.cmEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmployeeToolStripMenuItem,
            this.editEmployeeToolStripMenuItem,
            this.deleteEmployeeToolStripMenuItem});
            this.cmEmployees.Name = "cmEmployees";
            this.cmEmployees.Size = new System.Drawing.Size(200, 70);
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.addEmployeeToolStripMenuItem.Text = "Добавить сотрудника";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
            // 
            // editEmployeeToolStripMenuItem
            // 
            this.editEmployeeToolStripMenuItem.Name = "editEmployeeToolStripMenuItem";
            this.editEmployeeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.editEmployeeToolStripMenuItem.Text = "Изменить сотрудника";
            this.editEmployeeToolStripMenuItem.Click += new System.EventHandler(this.editEmployeeToolStripMenuItem_Click);
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            this.deleteEmployeeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.deleteEmployeeToolStripMenuItem.Text = "Удалить сотрудника";
            this.deleteEmployeeToolStripMenuItem.Click += new System.EventHandler(this.deleteEmployeeToolStripMenuItem_Click);
            // 
            // cmPositions
            // 
            this.cmPositions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPositionToolStripMenuItem,
            this.editPositionToolStripMenuItem,
            this.deletePositionToolStripMenuItem});
            this.cmPositions.Name = "cmPositions";
            this.cmPositions.Size = new System.Drawing.Size(194, 70);
            // 
            // addPositionToolStripMenuItem
            // 
            this.addPositionToolStripMenuItem.Name = "addPositionToolStripMenuItem";
            this.addPositionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addPositionToolStripMenuItem.Text = "Добавить должность";
            this.addPositionToolStripMenuItem.Click += new System.EventHandler(this.addPositionToolStripMenuItem_Click);
            // 
            // editPositionToolStripMenuItem
            // 
            this.editPositionToolStripMenuItem.Name = "editPositionToolStripMenuItem";
            this.editPositionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editPositionToolStripMenuItem.Text = "Изменить должность";
            this.editPositionToolStripMenuItem.Click += new System.EventHandler(this.editPositionToolStripMenuItem_Click);
            // 
            // deletePositionToolStripMenuItem
            // 
            this.deletePositionToolStripMenuItem.Name = "deletePositionToolStripMenuItem";
            this.deletePositionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.deletePositionToolStripMenuItem.Text = "Удалить должность";
            this.deletePositionToolStripMenuItem.Click += new System.EventHandler(this.deletePositionToolStripMenuItem_Click);
            // 
            // cmProducts
            // 
            this.cmProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductToolStripMenuItem,
            this.editProductToolStripMenuItem,
            this.deleteProductToolStripMenuItem});
            this.cmProducts.Name = "cmProducts";
            this.cmProducts.Size = new System.Drawing.Size(166, 70);
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addProductToolStripMenuItem.Text = "Добавить товар";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // editProductToolStripMenuItem
            // 
            this.editProductToolStripMenuItem.Name = "editProductToolStripMenuItem";
            this.editProductToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editProductToolStripMenuItem.Text = "Изменить товар";
            this.editProductToolStripMenuItem.Click += new System.EventHandler(this.editProductToolStripMenuItem_Click);
            // 
            // deleteProductToolStripMenuItem
            // 
            this.deleteProductToolStripMenuItem.Name = "deleteProductToolStripMenuItem";
            this.deleteProductToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deleteProductToolStripMenuItem.Text = "Удалить товар";
            this.deleteProductToolStripMenuItem.Click += new System.EventHandler(this.deleteProductToolStripMenuItem_Click);
            // 
            // cmProductTypes
            // 
            this.cmProductTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductTypeToolStripMenuItem,
            this.editProductTypeToolStripMenuItem,
            this.deleteProductTypeToolStripMenuItem});
            this.cmProductTypes.Name = "cmProductTypes";
            this.cmProductTypes.Size = new System.Drawing.Size(195, 70);
            // 
            // addProductTypeToolStripMenuItem
            // 
            this.addProductTypeToolStripMenuItem.Name = "addProductTypeToolStripMenuItem";
            this.addProductTypeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addProductTypeToolStripMenuItem.Text = "Добавить тип товара";
            this.addProductTypeToolStripMenuItem.Click += new System.EventHandler(this.addProductTypeToolStripMenuItem_Click);
            // 
            // editProductTypeToolStripMenuItem
            // 
            this.editProductTypeToolStripMenuItem.Name = "editProductTypeToolStripMenuItem";
            this.editProductTypeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.editProductTypeToolStripMenuItem.Text = "Изменить тип товара";
            this.editProductTypeToolStripMenuItem.Click += new System.EventHandler(this.editProductTypeToolStripMenuItem_Click);
            // 
            // deleteProductTypeToolStripMenuItem
            // 
            this.deleteProductTypeToolStripMenuItem.Name = "deleteProductTypeToolStripMenuItem";
            this.deleteProductTypeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deleteProductTypeToolStripMenuItem.Text = "Удалить тип товара";
            this.deleteProductTypeToolStripMenuItem.Click += new System.EventHandler(this.deleteProductTypeToolStripMenuItem_Click);
            // 
            // cmWarehouse
            // 
            this.cmWarehouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWarehouseItemToolStripMenuItem,
            this.editWarehouseItemToolStripMenuItem});
            this.cmWarehouse.Name = "cmWarehouse";
            this.cmWarehouse.Size = new System.Drawing.Size(227, 48);
            // 
            // addWarehouseItemToolStripMenuItem
            // 
            this.addWarehouseItemToolStripMenuItem.Name = "addWarehouseItemToolStripMenuItem";
            this.addWarehouseItemToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.addWarehouseItemToolStripMenuItem.Text = "Добавить товар на склад";
            this.addWarehouseItemToolStripMenuItem.Click += new System.EventHandler(this.addWarehouseItemToolStripMenuItem_Click);
            // 
            // editWarehouseItemToolStripMenuItem
            // 
            this.editWarehouseItemToolStripMenuItem.Name = "editWarehouseItemToolStripMenuItem";
            this.editWarehouseItemToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.editWarehouseItemToolStripMenuItem.Text = "Изменить товар на складе";
            this.editWarehouseItemToolStripMenuItem.Click += new System.EventHandler(this.editWarehouseItemToolStripMenuItem_Click);
            // 
            // cmSales
            // 
            this.cmSales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSaleToolStripMenuItem,
            this.editSaleToolStripMenuItem,
            this.deleteSaleToolStripMenuItem});
            this.cmSales.Name = "cmSales";
            this.cmSales.Size = new System.Drawing.Size(181, 70);
            // 
            // addSaleToolStripMenuItem
            // 
            this.addSaleToolStripMenuItem.Name = "addSaleToolStripMenuItem";
            this.addSaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addSaleToolStripMenuItem.Text = "Добавить продажу";
            this.addSaleToolStripMenuItem.Click += new System.EventHandler(this.addSaleToolStripMenuItem_Click);
            // 
            // editSaleToolStripMenuItem
            // 
            this.editSaleToolStripMenuItem.Name = "editSaleToolStripMenuItem";
            this.editSaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editSaleToolStripMenuItem.Text = "Изменить продажу";
            this.editSaleToolStripMenuItem.Click += new System.EventHandler(this.editSaleToolStripMenuItem_Click);
            // 
            // deleteSaleToolStripMenuItem
            // 
            this.deleteSaleToolStripMenuItem.Name = "deleteSaleToolStripMenuItem";
            this.deleteSaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteSaleToolStripMenuItem.Text = "Удалить продажу";
            this.deleteSaleToolStripMenuItem.Click += new System.EventHandler(this.deleteSaleToolStripMenuItem_Click);
            // 
            // cmOrders
            // 
            this.cmOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOrderToolStripMenuItem,
            this.editOrderToolStripMenuItem,
            this.deleteOrderToolStripMenuItem});
            this.cmOrders.Name = "cmOrders";
            this.cmOrders.Size = new System.Drawing.Size(166, 70);
            // 
            // addOrderToolStripMenuItem
            // 
            this.addOrderToolStripMenuItem.Name = "addOrderToolStripMenuItem";
            this.addOrderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addOrderToolStripMenuItem.Text = "Добавить заказ";
            this.addOrderToolStripMenuItem.Click += new System.EventHandler(this.addOrderToolStripMenuItem_Click);
            // 
            // editOrderToolStripMenuItem
            // 
            this.editOrderToolStripMenuItem.Name = "editOrderToolStripMenuItem";
            this.editOrderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editOrderToolStripMenuItem.Text = "Изменить заказ";
            this.editOrderToolStripMenuItem.Click += new System.EventHandler(this.editOrderToolStripMenuItem_Click);
            // 
            // deleteOrderToolStripMenuItem
            // 
            this.deleteOrderToolStripMenuItem.Name = "deleteOrderToolStripMenuItem";
            this.deleteOrderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deleteOrderToolStripMenuItem.Text = "Удалить заказ";
            this.deleteOrderToolStripMenuItem.Click += new System.EventHandler(this.deleteOrderToolStripMenuItem_Click);
            // 
            // cmShifts
            // 
            this.cmShifts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addShiftToolStripMenuItem,
            this.editShiftToolStripMenuItem});
            this.cmShifts.Name = "cmShifts";
            this.cmShifts.Size = new System.Drawing.Size(166, 48);
            // 
            // addShiftToolStripMenuItem
            // 
            this.addShiftToolStripMenuItem.Name = "addShiftToolStripMenuItem";
            this.addShiftToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addShiftToolStripMenuItem.Text = "Добавить смену";
            this.addShiftToolStripMenuItem.Click += new System.EventHandler(this.addShiftToolStripMenuItem_Click);
            // 
            // editShiftToolStripMenuItem
            // 
            this.editShiftToolStripMenuItem.Name = "editShiftToolStripMenuItem";
            this.editShiftToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editShiftToolStripMenuItem.Text = "Изменить смену";
            this.editShiftToolStripMenuItem.Click += new System.EventHandler(this.editShiftToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 568);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление складом музыкального магазина";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabEmployees.ResumeLayout(false);
            this.tabEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.tabPositions.ResumeLayout(false);
            this.tabPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabProductTypes.ResumeLayout(false);
            this.tabProductTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTypes)).EndInit();
            this.tabWarehouse.ResumeLayout(false);
            this.tabWarehouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.tabSales.ResumeLayout(false);
            this.tabSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.tabOrders.ResumeLayout(false);
            this.tabOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tabShifts.ResumeLayout(false);
            this.tabShifts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.cmEmployees.ResumeLayout(false);
            this.cmPositions.ResumeLayout(false);
            this.cmProducts.ResumeLayout(false);
            this.cmProductTypes.ResumeLayout(false);
            this.cmWarehouse.ResumeLayout(false);
            this.cmSales.ResumeLayout(false);
            this.cmOrders.ResumeLayout(false);
            this.cmShifts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnShifts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnProductTypes;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnPositions;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabPositions;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabProductTypes;
        private System.Windows.Forms.TabPage tabWarehouse;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabShifts;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvProductTypes;
        private System.Windows.Forms.DataGridView dgvWarehouse;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvShifts;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.ContextMenuStrip cmEmployees;
        private System.Windows.Forms.ToolStripMenuItem addEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEmployeeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmPositions;
        private System.Windows.Forms.ToolStripMenuItem addPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePositionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmProducts;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmProductTypes;
        private System.Windows.Forms.ToolStripMenuItem addProductTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProductTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductTypeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmWarehouse;
        private System.Windows.Forms.ToolStripMenuItem addWarehouseItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editWarehouseItemToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmSales;
        private System.Windows.Forms.ToolStripMenuItem addSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSaleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmOrders;
        private System.Windows.Forms.ToolStripMenuItem addOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteOrderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmShifts;
        private System.Windows.Forms.ToolStripMenuItem addShiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editShiftToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearchProducts;
        private System.Windows.Forms.Label lblSearchProducts;
        private System.Windows.Forms.TextBox txtSearchWarehouse;
        private System.Windows.Forms.Label lblSearchWarehouse;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnStartShift;
        private System.Windows.Forms.Label lblCurrentShift;
        private System.Windows.Forms.ComboBox cmbFilterEmployees;
        private System.Windows.Forms.Label lblFilterEmployees;
        private System.Windows.Forms.TextBox txtSearchEmployees;
        private System.Windows.Forms.Label lblSearchEmployees;
        private System.Windows.Forms.ComboBox cmbFilterPositions;
        private System.Windows.Forms.Label lblFilterPositions;
        private System.Windows.Forms.TextBox txtSearchPositions;
        private System.Windows.Forms.Label lblSearchPositions;
        private System.Windows.Forms.ComboBox cmbFilterProducts;
        private System.Windows.Forms.Label lblFilterProducts;
        private System.Windows.Forms.ComboBox cmbFilterProductTypes;
        private System.Windows.Forms.Label lblFilterProductTypes;
        private System.Windows.Forms.TextBox txtSearchProductTypes;
        private System.Windows.Forms.Label lblSearchProductTypes;
        private System.Windows.Forms.ComboBox cmbFilterWarehouse;
        private System.Windows.Forms.Label lblFilterWarehouse;
        private System.Windows.Forms.ComboBox cmbFilterSales;
        private System.Windows.Forms.Label lblFilterSales;
        private System.Windows.Forms.TextBox txtSearchSales;
        private System.Windows.Forms.Label lblSearchSales;
        private System.Windows.Forms.ComboBox cmbFilterOrders;
        private System.Windows.Forms.Label lblFilterOrders;
        private System.Windows.Forms.TextBox txtSearchOrders;
        private System.Windows.Forms.Label lblSearchOrders;
        private System.Windows.Forms.ComboBox cmbFilterShifts;
        private System.Windows.Forms.Label lblFilterShifts;
        private System.Windows.Forms.TextBox txtSearchShifts;
        private System.Windows.Forms.Label lblSearchShifts;
    }
}