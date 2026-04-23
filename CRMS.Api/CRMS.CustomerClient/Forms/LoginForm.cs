using CRMS.CustomerClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMS.CustomerClient.Forms
{
    public partial class LoginForm : Form
    {
        private ApiClient api;
        public LoginForm()
        {
            InitializeComponent();
            api = new ApiClient();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                await api.GetAsync("/cars");

                MessageBox.Show("Login successful.");

                CustomerDashboardForm dashboard = new CustomerDashboardForm(api);

                dashboard.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.ShowDialog();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
