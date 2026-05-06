using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMS.EnterpriseClient.Services;

namespace CRMS.EnterpriseClient
{
    public partial class Form1 : Form
    {
        private ApiClient api;
        public Form1()
        {
            InitializeComponent();
            api = new ApiClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (username == "" || password == "")
                {
                    MessageBox.Show("Please enter a username and password.");
                    return;
                }

                api.SetLogin(username, password);

                // This checks if the login is Staff/Admin.
                await api.GetAsync("/bookings");

                MessageBox.Show("Login successful.");

                EnterpriseDashboardForm dashboard = new EnterpriseDashboardForm(api, username);

                dashboard.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed. Make sure you are using a Staff or Admin account. " + ex.Message);
            }
        }
    }
}
