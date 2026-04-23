using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMS.CustomerClient.Services;
using CRMS.CustomerClient.Models;
using Newtonsoft.Json;


namespace CRMS.CustomerClient.Forms
{
    public partial class CustomerDashboardForm : Form
    {
        private ApiClient api;

        public CustomerDashboardForm(ApiClient apiClient)
        {
            InitializeComponent();
            api = apiClient;
        }

        private async void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            await LoadCars();
            await LoadBookings();
        }

        private async void btnLoadCars_Click(object sender, EventArgs e)
        {
            await LoadCars();
        }

        private async void btnLoadBookings_Click(object sender, EventArgs e)
        {
            await LoadBookings();
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
        private async System.Threading.Tasks.Task LoadBookings()
        {
            try
            {
                string json = await api.GetAsync("/bookings/my");

                List<Booking> bookings = JsonConvert.DeserializeObject<List<Booking>>(json);

                dgvBookings.DataSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load bookings: " + ex.Message);
            }
        }
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null)
            {
                MessageBox.Show("Please select a car.");
                return;
            }

            Car selectedCar = (Car)dgvCars.CurrentRow.DataBoundItem;

            string message = "";

            message += "Make: " + selectedCar.Make + Environment.NewLine;
            message += "Model: " + selectedCar.Model + Environment.NewLine;
            message += "Year: " + selectedCar.Year + Environment.NewLine;
            message += "Category: " + selectedCar.Category + Environment.NewLine;
            message += "Daily Rate: $" + selectedCar.DailyRate + Environment.NewLine;
            message += "Licence Plate: " + selectedCar.LicencePlate + Environment.NewLine;
            message += "Colour: " + selectedCar.Color + Environment.NewLine;
            message += "Status: " + selectedCar.Status;

            MessageBox.Show(message, "Car Details");
        }
        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null)
            {
                MessageBox.Show("Please select a car.");
                return;
            }

            Car selectedCar = (Car)dgvCars.CurrentRow.DataBoundItem;

            CreateBookingForm bookingForm = new CreateBookingForm(api, selectedCar);

            bookingForm.ShowDialog();
        }
        private async void btnCancelBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBookings.CurrentRow == null)
                {
                    MessageBox.Show("Please select a booking.");
                    return;
                }

                Booking selectedBooking = (Booking)dgvBookings.CurrentRow.DataBoundItem;

                if (selectedBooking.Status != "Pending")
                {
                    MessageBox.Show("Only pending bookings can be cancelled.");
                    return;
                }

                DialogResult answer = MessageBox.Show(
                    "Are you sure you want to cancel this booking?",
                    "Cancel Booking",
                    MessageBoxButtons.YesNo);
                if (answer == DialogResult.No)
                {
                    return;
                }

                await api.DeleteAsync("/bookings/" + selectedBooking.Id);

                MessageBox.Show("Booking cancelled.");

                await LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not cancel booking: " + ex.Message);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Close();
        }
    }
}
