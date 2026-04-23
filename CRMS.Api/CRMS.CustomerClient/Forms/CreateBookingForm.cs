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

namespace CRMS.CustomerClient.Forms
{
    public partial class CreateBookingForm : Form
    {
        private ApiClient api;
        private Car car;
        public CreateBookingForm(ApiClient apiClient, Car selectedCar)
        {
            InitializeComponent();
            api = apiClient;
            car = selectedCar;
            lblCarInfo.Text = car.Year + " " + car.Make + " " + car.Model + " - $" + car.DailyRate + " per day";

            dtpPickup.Value = DateTime.Today;

            dtpReturn.Value = DateTime.Today.AddDays(1);
        }

        private void CreateBookingForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpReturn.Value <= dtpPickup.Value)
                {
                    MessageBox.Show("Return date must be after pickup date.");
                    return;
                }

                var bookingRequest = new
                {
                    CarId = car.Id,
                    PickupDate = dtpPickup.Value,
                    ReturnDate = dtpReturn.Value
                };

                await api.PostAsync("/bookings", bookingRequest);

                MessageBox.Show("Booking request submitted.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed: " + ex.Message);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
