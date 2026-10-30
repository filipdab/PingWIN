namespace PingWIN
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.flowInput = new System.Windows.Forms.FlowLayoutPanel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblInterval = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRtt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip();
            this.menuPingNow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.flowBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPingNow = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pingTimer = new System.Windows.Forms.Timer();
            this.panelHeader.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.flowInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.gridMenu.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.flowBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.panelHeader.Controls.Add(this.btnAbout);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1650, 105);
            this.panelHeader.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.AutoSize = true;
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.btnAbout.Location = new System.Drawing.Point(1416, 28);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnAbout.Size = new System.Drawing.Size(210, 48);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "ⓘ  O autorze";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 63);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(459, 28);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "Monitor dostępności hostów w czasie rzeczywistym";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 48);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "PingWIN";
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.flowInput);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(0, 105);
            this.panelInput.Margin = new System.Windows.Forms.Padding(4);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(24, 21, 24, 15);
            this.panelInput.Size = new System.Drawing.Size(1650, 87);
            this.panelInput.TabIndex = 1;
            // 
            // flowInput
            // 
            this.flowInput.Controls.Add(this.txtAddress);
            this.flowInput.Controls.Add(this.txtName);
            this.flowInput.Controls.Add(this.btnAdd);
            this.flowInput.Controls.Add(this.lblInterval);
            this.flowInput.Controls.Add(this.numInterval);
            this.flowInput.Controls.Add(this.lblTimeout);
            this.flowInput.Controls.Add(this.numTimeout);
            this.flowInput.Controls.Add(this.btnStartStop);
            this.flowInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowInput.Location = new System.Drawing.Point(24, 21);
            this.flowInput.Margin = new System.Windows.Forms.Padding(4);
            this.flowInput.Name = "flowInput";
            this.flowInput.Size = new System.Drawing.Size(1602, 51);
            this.flowInput.TabIndex = 0;
            this.flowInput.WrapContents = false;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.txtAddress.Location = new System.Drawing.Point(0, 4);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(314, 35);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.txtName.Location = new System.Drawing.Point(326, 4);
            this.txtName.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(254, 35);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(92)))), ((int)(((byte)(255)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(592, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnAdd.Size = new System.Drawing.Size(176, 57);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+  Dodaj";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.lblInterval.Location = new System.Drawing.Point(804, 9);
            this.lblInterval.Margin = new System.Windows.Forms.Padding(36, 9, 6, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(127, 28);
            this.lblInterval.TabIndex = 3;
            this.lblInterval.Text = "Interwał (ms):";
            // 
            // numInterval
            // 
            this.numInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.numInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.numInterval.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numInterval.Location = new System.Drawing.Point(937, 4);
            this.numInterval.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.numInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(120, 33);
            this.numInterval.TabIndex = 3;
            this.numInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.numInterval_ValueChanged);
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.lblTimeout.Location = new System.Drawing.Point(1081, 9);
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(12, 9, 6, 0);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(130, 28);
            this.lblTimeout.TabIndex = 4;
            this.lblTimeout.Text = "Timeout (ms):";
            // 
            // numTimeout
            // 
            this.numTimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.numTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.numTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeout.Location = new System.Drawing.Point(1217, 4);
            this.numTimeout.Margin = new System.Windows.Forms.Padding(0, 4, 24, 0);
            this.numTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(120, 33);
            this.numTimeout.TabIndex = 4;
            this.numTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnStartStop
            // 
            this.btnStartStop.AutoSize = true;
            this.btnStartStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(160)))), ((int)(((byte)(98)))));
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.FlatAppearance.BorderSize = 0;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStartStop.ForeColor = System.Drawing.Color.White;
            this.btnStartStop.Location = new System.Drawing.Point(1361, 0);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnStartStop.Size = new System.Drawing.Size(165, 57);
            this.btnStartStop.TabIndex = 5;
            this.btnStartStop.Text = "▶  Start";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.grid);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 192);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(24, 6, 24, 0);
            this.panelGrid.Size = new System.Drawing.Size(1650, 657);
            this.panelGrid.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeight = 38;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colName,
            this.colAddress,
            this.colRtt,
            this.colAvg,
            this.colMinMax,
            this.colLoss,
            this.colSentReceived,
            this.colHistory});
            this.grid.ContextMenuStrip = this.gridMenu;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(54)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle4;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.grid.Location = new System.Drawing.Point(24, 6);
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 62;
            this.grid.RowTemplate.Height = 38;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1602, 651);
            this.grid.TabIndex = 0;
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.grid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_CellMouseDown);
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 20F;
            this.colStatus.HeaderText = "STATUS";
            this.colStatus.MinimumWidth = 130;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colName
            // 
            this.colName.FillWeight = 15F;
            this.colName.HeaderText = "NAZWA  ✎";
            this.colName.MinimumWidth = 100;
            this.colName.Name = "colName";
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colName.ToolTipText = "Kliknij dwukrotnie, aby zmienić nazwę";
            // 
            // colAddress
            // 
            this.colAddress.FillWeight = 15F;
            this.colAddress.HeaderText = "ADRES";
            this.colAddress.MinimumWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRtt
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRtt.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRtt.FillWeight = 8F;
            this.colRtt.HeaderText = "CZAS";
            this.colRtt.MinimumWidth = 60;
            this.colRtt.Name = "colRtt";
            this.colRtt.ReadOnly = true;
            this.colRtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAvg
            // 
            this.colAvg.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAvg.FillWeight = 8F;
            this.colAvg.HeaderText = "ŚREDNIA";
            this.colAvg.MinimumWidth = 60;
            this.colAvg.Name = "colAvg";
            this.colAvg.ReadOnly = true;
            this.colAvg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMinMax
            // 
            this.colMinMax.DefaultCellStyle = dataGridViewCellStyle3;
            this.colMinMax.FillWeight = 10F;
            this.colMinMax.HeaderText = "MIN / MAX";
            this.colMinMax.MinimumWidth = 80;
            this.colMinMax.Name = "colMinMax";
            this.colMinMax.ReadOnly = true;
            this.colMinMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colLoss
            // 
            this.colLoss.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLoss.FillWeight = 7F;
            this.colLoss.HeaderText = "UTRATA";
            this.colLoss.MinimumWidth = 60;
            this.colLoss.Name = "colLoss";
            this.colLoss.ReadOnly = true;
            this.colLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSentReceived
            // 
            this.colSentReceived.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSentReceived.FillWeight = 9F;
            this.colSentReceived.HeaderText = "WYSŁ./ODB.";
            this.colSentReceived.MinimumWidth = 90;
            this.colSentReceived.Name = "colSentReceived";
            this.colSentReceived.ReadOnly = true;
            this.colSentReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colHistory
            // 
            this.colHistory.FillWeight = 22F;
            this.colHistory.HeaderText = "HISTORIA";
            this.colHistory.MinimumWidth = 120;
            this.colHistory.Name = "colHistory";
            this.colHistory.ReadOnly = true;
            this.colHistory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridMenu
            // 
            this.gridMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.gridMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPingNow,
            this.menuReset,
            this.menuCopy,
            this.menuSeparator,
            this.menuRemove});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.ShowImageMargin = false;
            this.gridMenu.Size = new System.Drawing.Size(209, 146);
            this.gridMenu.Opening += new System.ComponentModel.CancelEventHandler(this.gridMenu_Opening);
            // 
            // menuPingNow
            // 
            this.menuPingNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.menuPingNow.Name = "menuPingNow";
            this.menuPingNow.Size = new System.Drawing.Size(208, 34);
            this.menuPingNow.Text = "Pinguj teraz";
            this.menuPingNow.Click += new System.EventHandler(this.btnPingNow_Click);
            // 
            // menuReset
            // 
            this.menuReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.menuReset.Name = "menuReset";
            this.menuReset.Size = new System.Drawing.Size(208, 34);
            this.menuReset.Text = "Resetuj statystyki";
            this.menuReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(208, 34);
            this.menuCopy.Text = "Kopiuj adres";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(205, 6);
            // 
            // menuRemove
            // 
            this.menuRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(108)))));
            this.menuRemove.Name = "menuRemove";
            this.menuRemove.ShortcutKeyDisplayString = "Del";
            this.menuRemove.Size = new System.Drawing.Size(208, 34);
            this.menuRemove.Text = "Usuń";
            this.menuRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.flowBottom);
            this.panelBottom.Controls.Add(this.lblSummary);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 849);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(24, 18, 24, 18);
            this.panelBottom.Size = new System.Drawing.Size(1650, 81);
            this.panelBottom.TabIndex = 3;
            // 
            // flowBottom
            // 
            this.flowBottom.Controls.Add(this.btnRemove);
            this.flowBottom.Controls.Add(this.btnReset);
            this.flowBottom.Controls.Add(this.btnPingNow);
            this.flowBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowBottom.Location = new System.Drawing.Point(24, 18);
            this.flowBottom.Margin = new System.Windows.Forms.Padding(4);
            this.flowBottom.Name = "flowBottom";
            this.flowBottom.Size = new System.Drawing.Size(1092, 45);
            this.flowBottom.TabIndex = 0;
            this.flowBottom.WrapContents = false;
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSize = true;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(108)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(108)))));
            this.btnRemove.Location = new System.Drawing.Point(0, 0);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnRemove.Size = new System.Drawing.Size(274, 48);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "✕  Usuń zaznaczone";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.btnReset.Location = new System.Drawing.Point(286, 0);
            this.btnReset.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnReset.Size = new System.Drawing.Size(268, 48);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "↺  Resetuj statystyki";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPingNow
            // 
            this.btnPingNow.AutoSize = true;
            this.btnPingNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            this.btnPingNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPingNow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.btnPingNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPingNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.btnPingNow.Location = new System.Drawing.Point(566, 0);
            this.btnPingNow.Margin = new System.Windows.Forms.Padding(0);
            this.btnPingNow.Name = "btnPingNow";
            this.btnPingNow.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnPingNow.Size = new System.Drawing.Size(216, 48);
            this.btnPingNow.TabIndex = 2;
            this.btnPingNow.Text = "⚡  Pinguj teraz";
            this.btnPingNow.UseVisualStyleBackColor = false;
            this.btnPingNow.Click += new System.EventHandler(this.btnPingNow_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.lblSummary.Location = new System.Drawing.Point(1116, 18);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(510, 45);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSummary.Paint += new System.Windows.Forms.PaintEventHandler(this.lblSummary_Paint);
            // 
            // pingTimer
            // 
            this.pingTimer.Interval = 1000;
            this.pingTimer.Tick += new System.EventHandler(this.pingTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1650, 930);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1429, 602);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PingWIN – monitor ping";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.flowInput.ResumeLayout(false);
            this.flowInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.gridMenu.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.flowBottom.ResumeLayout(false);
            this.flowBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.FlowLayoutPanel flowInput;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRtt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistory;
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem menuPingNow;
        private System.Windows.Forms.ToolStripMenuItem menuReset;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuRemove;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.FlowLayoutPanel flowBottom;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPingNow;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Timer pingTimer;
    }
}
