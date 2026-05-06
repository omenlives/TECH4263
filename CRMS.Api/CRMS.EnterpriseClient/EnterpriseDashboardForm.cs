using CRMS.EnterpriseClient.Models;
using CRMS.EnterpriseClient.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMS.EnterpriseClient
{
    public partial class EnterpriseDashboardForm : Form
    {
        private ApiClient api;
        private string username;
        public EnterpriseDashboardForm()
        {
            InitializeComponent();
        }
        public EnterpriseDashboardForm(ApiClient apiClient, string loggedInUsername)
        {
            InitializeComponent();

            api = apiClient;

            username = loggedInUsername;
        }
        private async void EnterpriseDashboardForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Rented");
            cmbStatus.Items.Add("Maintenance");
            cmbStatus.SelectedIndex = 0;

            await LoadBookings();

            await LoadCars();

            await TryLoadUsers();
        }

        private async System.Threading.Tasks.Task LoadBookings()
        {
            try
            {
                string json = await api.GetAsync("/bookings");

                List<Booking> bookings = JsonConvert.DeserializeObject<List<Booking>>(json);

                dgvBookings.DataSource = bookings;

                if (dgvBookings.Columns["Customer"] != null)
                {
                    dgvBookings.Columns["Customer"].Visible = false;
                }

                if (dgvBookings.Columns["Car"] != null)
                {
                    dgvBookings.Columns["Car"].Visible = false;
                }

                if (dgvBookings.Columns["CustomerName"] != null)
                {
                    dgvBookings.Columns["CustomerName"].HeaderText = "Customer";
                }

                if (dgvBookings.Columns["CarName"] != null)
                {
                    dgvBookings.Columns["CarName"].HeaderText = "Car";
                }

                if (dgvBookings.Columns["CustomerId"] != null)
                {
                    dgvBookings.Columns["CustomerId"].Visible = false;
                }

                if (dgvBookings.Columns["CarId"] != null)
                {
                    dgvBookings.Columns["CarId"].Visible = false;
                }

                if (dgvBookings.Columns["ApprovedById"] != null)
                {
                    dgvBookings.Columns["ApprovedById"].Visible = false;
                }
                if (dgvBookings.Columns["CreatedAt"] != null)
                {
                    dgvBookings.Columns["CreatedAt"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load bookings: " + ex.Message);
            }
        }
        private async System.Threading.Tasks.Task LoadCars()
        {
            try
            {
                string json = await api.GetAsync("/cars");

                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);

                dgvCars.DataSource = cars;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load cars: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task TryLoadUsers()
        {
            try
            {
                string json = await api.GetAsync("/users");

                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                btnLoadUsers.Visible = true;
                dgvUsers.Visible = true;

                btnAddCar.Visible = true;
                btnUpdateCar.Visible = true;
                btnDeleteCar.Visible = true;
                btnLoadCars.Visible = true;
                dgvCars.Visible = true;

                txtMake.Visible = true;
                txtModel.Visible = true;
                txtYear.Visible = true;
                txtCategory.Visible = true;
                txtDailyRate.Visible = true;
                txtLicencePlate.Visible = true;
                txtColor.Visible = true;
                cmbStatus.Visible = true;

                lblMake.Visible = true;
                lblModel.Visible = true;
                lblYear.Visible = true;
                lblCategory.Visible = true;
                lblDailyRate.Visible = true;
                lblLicensePlate.Visible = true;
                lblColor.Visible = true;
                lblStatus.Visible = true;
                lblCarCatalog.Visible = true;
                lblUserCatalog.Visible = true;
                lblBookingHeading.Visible = true;
            }
            catch
            {
                // Staff users cannot access /users.
                // Hide Admin-only controls.
                btnLoadUsers.Visible = false;
                dgvUsers.Visible = false;

                btnAddCar.Visible = false;
                btnUpdateCar.Visible = false;
                btnDeleteCar.Visible = false;
                btnLoadCars.Visible = false;
                dgvCars.Visible = false;

                txtMake.Visible = false;
                txtModel.Visible = false;
                txtYear.Visible = false;
                txtCategory.Visible = false;
                txtDailyRate.Visible = false;
                txtLicencePlate.Visible = false;
                txtColor.Visible = false;
                cmbStatus.Visible = false;

                lblMake.Visible = false;
                lblModel.Visible = false;
                lblYear.Visible = false;
                lblCategory.Visible = false;
                lblDailyRate.Visible = false;
                lblLicensePlate.Visible = false;
                lblColor.Visible = false;
                lblStatus.Visible = false;
                lblCarCatalog.Visible = false;
                lblUserCatalog.Visible = false;
                lblBookingHeading.Visible = true;
            }
        }
        private async void btnLoadBookings_Click(object sender, EventArgs e)
        {
            await LoadBookings();
        }

        private async void btnLoadCars_Click(object sender, EventArgs e)
        {
            await LoadCars();
        }

        private async void btnLoadUsers_Click(object sender, EventArgs e)
        {
            await TryLoadUsers();
        }
        private Booking GetSelectedBooking()
        {
            if (dgvBookings.CurrentRow == null)
            {
                return null;
            }

            return (Booking)dgvBookings.CurrentRow.DataBoundItem;
        }

        private Car GetSelectedCar()
        {
            if (dgvCars.CurrentRow == null)
            {
                return null;
            }

            return (Car)dgvCars.CurrentRow.DataBoundItem;
        }
        private async void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Booking booking = GetSelectedBooking();

                if (booking == null)
                {
                    MessageBox.Show("Please select a booking.");
                    return;
                }

                await api.PutAsync("/bookings/" + booking.Id + "/approve", new { });

                MessageBox.Show("Booking approved.");

                await LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not approve booking: " + ex.Message);
            }
        }
        private async void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                Booking booking = GetSelectedBooking();

                if (booking == null)
                {
                    MessageBox.Show("Please select a booking.");
                    return;
                }

                await api.PutAsync("/bookings/" + booking.Id + "/reject", new { });

                MessageBox.Show("Booking rejected.");

                await LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not reject booking: " + ex.Message);
            }
        }
        private async void btnActive_Click(object sender, EventArgs e)
        {
            try
            {
                Booking booking = GetSelectedBooking();

                if (booking == null)
                {
                    MessageBox.Show("Please select a booking.");
                    return;
                }

                await api.PutAsync("/bookings/" + booking.Id + "/active", new { });

                MessageBox.Show("Booking marked active.");

                await LoadBookings();
                await LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not mark booking active: " + ex.Message);
            }
        }
        private async void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                Booking booking = GetSelectedBooking();

                if (booking == null)
                {
                    MessageBox.Show("Please select a booking.");
                    return;
                }

                await api.PutAsync("/bookings/" + booking.Id + "/complete", new { });

                MessageBox.Show("Booking completed.");

                await LoadBookings();
                await LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not complete booking: " + ex.Message);
            }
        }
        private async void btnAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMake.Text == "" ||
                    txtModel.Text == "" ||
                    txtYear.Text == "" ||
                    txtCategory.Text == "" ||
                    txtDailyRate.Text == "" ||
                    txtLicencePlate.Text == "" ||
                    txtColor.Text == "")
                {
                    MessageBox.Show("Please fill out all car fields.");
                    return;
                }
                var carData = new
                {
                    Make = txtMake.Text,
                    Model = txtModel.Text,
                    Year = int.Parse(txtYear.Text),
                    Category = txtCategory.Text,
                    DailyRate = decimal.Parse(txtDailyRate.Text),
                    LicencePlate = txtLicencePlate.Text,
                    Color = txtColor.Text,
                    Status = cmbStatus.Text
                };

                await api.PostAsync("/cars", carData);

                MessageBox.Show("Car added.");

                await LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add car: " + ex.Message);
            }
        }
        private async void btnUpdateCar_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = GetSelectedCar();

                if (car == null)
                {
                    MessageBox.Show("Please select a car.");
                    return;
                }

                var carData = new
                {
                    Make = txtMake.Text,
                    Model = txtModel.Text,
                    Year = int.Parse(txtYear.Text),
                    Category = txtCategory.Text,
                    DailyRate = decimal.Parse(txtDailyRate.Text),
                    LicencePlate = txtLicencePlate.Text,
                    Color = txtColor.Text,
                    Status = cmbStatus.Text
                };
                await api.PutAsync("/cars/" + car.Id, carData);

                MessageBox.Show("Car updated.");

                await LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update car: " + ex.Message);
            }
        }

        private async void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                Car car = GetSelectedCar();

                if (car == null)
                {
                    MessageBox.Show("Please select a car.");
                    return;
                }

                DialogResult answer = MessageBox.Show(
                    "Are you sure you want to delete this car?",
                    "Delete Car",
                    MessageBoxButtons.YesNo);

                if (answer == DialogResult.No)
                {
                    return;
                }

                await api.DeleteAsync("/cars/" + car.Id);

                MessageBox.Show("Car deleted.");

                await LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete car: " + ex.Message);
            }
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Car car = GetSelectedCar();

            if (car == null)
            {
                return;
            }
            txtMake.Text = car.Make;
            txtModel.Text = car.Model;
            txtYear.Text = car.Year.ToString();
            txtCategory.Text = car.Category;
            txtDailyRate.Text = car.DailyRate.ToString();
            txtLicencePlate.Text = car.LicencePlate;
            txtColor.Text = car.Color;
            cmbStatus.Text = car.Status;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();

            loginForm.Show();

            this.Close();
        }
    }
}
