namespace CRMS.EnterpriseClient
{
    partial class EnterpriseDashboardForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.btnLoadBookings = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.btnLoadCars = new System.Windows.Forms.Button();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDailyRate = new System.Windows.Forms.Label();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtDailyRate = new System.Windows.Forms.TextBox();
            this.txtLicencePlate = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.btnUpdateCar = new System.Windows.Forms.Button();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnLoadUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblBookingHeading = new System.Windows.Forms.Label();
            this.lblUserCatalog = new System.Windows.Forms.Label();
            this.lblCarCatalog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(869, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Enterprise Dashboard";
            // 
            // dgvBookings
            // 
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(639, 95);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.RowTemplate.Height = 24;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(718, 631);
            this.dgvBookings.TabIndex = 1;
            // 
            // btnLoadBookings
            // 
            this.btnLoadBookings.Location = new System.Drawing.Point(678, 751);
            this.btnLoadBookings.Name = "btnLoadBookings";
            this.btnLoadBookings.Size = new System.Drawing.Size(142, 23);
            this.btnLoadBookings.TabIndex = 33;
            this.btnLoadBookings.Text = "Load Bookings";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(852, 751);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 32;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(975, 751);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(1093, 751);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(101, 23);
            this.btnActive.TabIndex = 5;
            this.btnActive.Text = "Mark Active";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(1220, 751);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(137, 23);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // dgvCars
            // 
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(1363, 95);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.RowTemplate.Height = 24;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(527, 631);
            this.dgvCars.TabIndex = 7;
            this.dgvCars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellClick);
            // 
            // btnLoadCars
            // 
            this.btnLoadCars.Location = new System.Drawing.Point(1449, 740);
            this.btnLoadCars.Name = "btnLoadCars";
            this.btnLoadCars.Size = new System.Drawing.Size(83, 23);
            this.btnLoadCars.TabIndex = 8;
            this.btnLoadCars.Text = "Load Cars";
            this.btnLoadCars.UseVisualStyleBackColor = true;
            this.btnLoadCars.Click += new System.EventHandler(this.btnLoadCars_Click);
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(1626, 769);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(100, 22);
            this.txtMake.TabIndex = 9;
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(1506, 769);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(41, 16);
            this.lblMake.TabIndex = 10;
            this.lblMake.Text = "Make";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(1506, 794);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(45, 16);
            this.lblModel.TabIndex = 11;
            this.lblModel.Text = "Model";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(1506, 825);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(36, 16);
            this.lblYear.TabIndex = 12;
            this.lblYear.Text = "Year";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(1506, 853);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 13;
            this.lblCategory.Text = "Category";
            // 
            // lblDailyRate
            // 
            this.lblDailyRate.AutoSize = true;
            this.lblDailyRate.Location = new System.Drawing.Point(1506, 887);
            this.lblDailyRate.Name = "lblDailyRate";
            this.lblDailyRate.Size = new System.Drawing.Size(70, 16);
            this.lblDailyRate.TabIndex = 14;
            this.lblDailyRate.Text = "Daily Rate";
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Location = new System.Drawing.Point(1506, 916);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(96, 16);
            this.lblLicensePlate.TabIndex = 15;
            this.lblLicensePlate.Text = "Licenese Plate";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(1508, 944);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(39, 16);
            this.lblColor.TabIndex = 16;
            this.lblColor.Text = "Color";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(1624, 797);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(100, 22);
            this.txtModel.TabIndex = 17;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(1626, 825);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 22);
            this.txtYear.TabIndex = 18;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(1624, 853);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 22);
            this.txtCategory.TabIndex = 19;
            // 
            // txtDailyRate
            // 
            this.txtDailyRate.Location = new System.Drawing.Point(1624, 881);
            this.txtDailyRate.Name = "txtDailyRate";
            this.txtDailyRate.Size = new System.Drawing.Size(100, 22);
            this.txtDailyRate.TabIndex = 20;
            // 
            // txtLicencePlate
            // 
            this.txtLicencePlate.Location = new System.Drawing.Point(1624, 909);
            this.txtLicencePlate.Name = "txtLicencePlate";
            this.txtLicencePlate.Size = new System.Drawing.Size(100, 22);
            this.txtLicencePlate.TabIndex = 21;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(1624, 941);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 22);
            this.txtColor.TabIndex = 22;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Available",
            "Rented",
            "Maintenance"});
            this.cmbStatus.Location = new System.Drawing.Point(1624, 969);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbStatus.TabIndex = 23;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(1508, 969);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 31;
            this.lblStatus.Text = "Status";
            // 
            // btnAddCar
            // 
            this.btnAddCar.Location = new System.Drawing.Point(1538, 740);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(75, 23);
            this.btnAddCar.TabIndex = 25;
            this.btnAddCar.Text = "Add Car";
            this.btnAddCar.UseVisualStyleBackColor = true;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // btnUpdateCar
            // 
            this.btnUpdateCar.Location = new System.Drawing.Point(1619, 740);
            this.btnUpdateCar.Name = "btnUpdateCar";
            this.btnUpdateCar.Size = new System.Drawing.Size(94, 23);
            this.btnUpdateCar.TabIndex = 26;
            this.btnUpdateCar.Text = "Update Car";
            this.btnUpdateCar.UseVisualStyleBackColor = true;
            this.btnUpdateCar.Click += new System.EventHandler(this.btnUpdateCar_Click);
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.Location = new System.Drawing.Point(1719, 740);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(81, 23);
            this.btnDeleteCar.TabIndex = 27;
            this.btnDeleteCar.Text = "Delete Car";
            this.btnDeleteCar.UseVisualStyleBackColor = true;
            this.btnDeleteCar.Click += new System.EventHandler(this.btnDeleteCar_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 95);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(621, 631);
            this.dgvUsers.TabIndex = 28;
            // 
            // btnLoadUsers
            // 
            this.btnLoadUsers.Location = new System.Drawing.Point(231, 751);
            this.btnLoadUsers.Name = "btnLoadUsers";
            this.btnLoadUsers.Size = new System.Drawing.Size(101, 23);
            this.btnLoadUsers.TabIndex = 29;
            this.btnLoadUsers.Text = "Load Users";
            this.btnLoadUsers.UseVisualStyleBackColor = true;
            this.btnLoadUsers.Click += new System.EventHandler(this.btnLoadUsers_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(959, 797);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 23);
            this.btnLogout.TabIndex = 30;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblBookingHeading
            // 
            this.lblBookingHeading.AutoSize = true;
            this.lblBookingHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingHeading.Location = new System.Drawing.Point(971, 60);
            this.lblBookingHeading.Name = "lblBookingHeading";
            this.lblBookingHeading.Size = new System.Drawing.Size(69, 20);
            this.lblBookingHeading.TabIndex = 34;
            this.lblBookingHeading.Text = "Booking";
            // 
            // lblUserCatalog
            // 
            this.lblUserCatalog.AutoSize = true;
            this.lblUserCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCatalog.Location = new System.Drawing.Point(269, 72);
            this.lblUserCatalog.Name = "lblUserCatalog";
            this.lblUserCatalog.Size = new System.Drawing.Size(107, 20);
            this.lblUserCatalog.TabIndex = 35;
            this.lblUserCatalog.Text = "User Catalog";
            // 
            // lblCarCatalog
            // 
            this.lblCarCatalog.AutoSize = true;
            this.lblCarCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarCatalog.Location = new System.Drawing.Point(1568, 72);
            this.lblCarCatalog.Name = "lblCarCatalog";
            this.lblCarCatalog.Size = new System.Drawing.Size(98, 20);
            this.lblCarCatalog.TabIndex = 36;
            this.lblCarCatalog.Text = "Car Catalog";
            // 
            // EnterpriseDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.lblCarCatalog);
            this.Controls.Add(this.lblUserCatalog);
            this.Controls.Add(this.lblBookingHeading);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLoadUsers);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnDeleteCar);
            this.Controls.Add(this.btnUpdateCar);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtLicencePlate);
            this.Controls.Add(this.txtDailyRate);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.lblDailyRate);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblMake);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.btnLoadCars);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnLoadBookings);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.lblTitle);
            this.Name = "EnterpriseDashboardForm";
            this.Text = "EnterpriseDashboardForm";
            this.Load += new System.EventHandler(this.EnterpriseDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnLoadBookings;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Button btnLoadCars;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDailyRate;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtDailyRate;
        private System.Windows.Forms.TextBox txtLicencePlate;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.Button btnUpdateCar;
        private System.Windows.Forms.Button btnDeleteCar;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnLoadUsers;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblBookingHeading;
        private System.Windows.Forms.Label lblUserCatalog;
        private System.Windows.Forms.Label lblCarCatalog;
    }
}