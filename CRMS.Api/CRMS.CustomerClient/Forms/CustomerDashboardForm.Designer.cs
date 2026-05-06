namespace CRMS.CustomerClient.Forms
{
    partial class CustomerDashboardForm
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
            this.btnLoadCars = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnCreateBooking = new System.Windows.Forms.Button();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.btnLoadBookings = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblBooking = new System.Windows.Forms.Label();
            this.lblCars = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadCars
            // 
            this.btnLoadCars.Location = new System.Drawing.Point(144, 489);
            this.btnLoadCars.Name = "btnLoadCars";
            this.btnLoadCars.Size = new System.Drawing.Size(113, 23);
            this.btnLoadCars.TabIndex = 0;
            this.btnLoadCars.Text = "Load Cars";
            this.btnLoadCars.UseVisualStyleBackColor = true;
            this.btnLoadCars.Click += new System.EventHandler(this.btnLoadCars_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(571, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 29);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Customer Dashboard";
            // 
            // dgvCars
            // 
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(12, 98);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.RowTemplate.Height = 24;
            this.dgvCars.Size = new System.Drawing.Size(659, 385);
            this.dgvCars.TabIndex = 2;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(403, 489);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(114, 23);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "View Car Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnCreateBooking
            // 
            this.btnCreateBooking.Location = new System.Drawing.Point(872, 489);
            this.btnCreateBooking.Name = "btnCreateBooking";
            this.btnCreateBooking.Size = new System.Drawing.Size(136, 23);
            this.btnCreateBooking.TabIndex = 4;
            this.btnCreateBooking.Text = "Create Booking";
            this.btnCreateBooking.UseVisualStyleBackColor = true;
            this.btnCreateBooking.Click += new System.EventHandler(this.btnCreateBooking_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(739, 98);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.RowTemplate.Height = 24;
            this.dgvBookings.Size = new System.Drawing.Size(626, 385);
            this.dgvBookings.TabIndex = 5;
            // 
            // btnLoadBookings
            // 
            this.btnLoadBookings.Location = new System.Drawing.Point(1047, 489);
            this.btnLoadBookings.Name = "btnLoadBookings";
            this.btnLoadBookings.Size = new System.Drawing.Size(105, 23);
            this.btnLoadBookings.TabIndex = 6;
            this.btnLoadBookings.Text = "My Bookings";
            this.btnLoadBookings.UseVisualStyleBackColor = true;
            this.btnLoadBookings.Click += new System.EventHandler(this.btnLoadBookings_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(1186, 489);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(172, 23);
            this.btnCancelBooking.TabIndex = 7;
            this.btnCancelBooking.Text = "Cancel Pending Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(647, 626);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblBooking
            // 
            this.lblBooking.AutoSize = true;
            this.lblBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooking.Location = new System.Drawing.Point(1113, 75);
            this.lblBooking.Name = "lblBooking";
            this.lblBooking.Size = new System.Drawing.Size(78, 20);
            this.lblBooking.TabIndex = 9;
            this.lblBooking.Text = "Bookings";
            // 
            // lblCars
            // 
            this.lblCars.AutoSize = true;
            this.lblCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCars.Location = new System.Drawing.Point(303, 75);
            this.lblCars.Name = "lblCars";
            this.lblCars.Size = new System.Drawing.Size(45, 20);
            this.lblCars.TabIndex = 10;
            this.lblCars.Text = "Cars";
            // 
            // CustomerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 823);
            this.Controls.Add(this.lblCars);
            this.Controls.Add(this.lblBooking);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnLoadBookings);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.btnCreateBooking);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoadCars);
            this.Name = "CustomerDashboardForm";
            this.Text = "CustomerDashboardForm";
            this.Load += new System.EventHandler(this.CustomerDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadCars;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnCreateBooking;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnLoadBookings;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblBooking;
        private System.Windows.Forms.Label lblCars;
    }
}