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
    public partial class RegisterForm : Form
    {
        private ApiClient api;

        public RegisterForm()
        {
            InitializeComponent();
            api = new ApiClient();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" ||
                    txtPassword.Text == "" ||
                    txtFullName.Text == "" ||
                    txtEmail.Text == "")
                {
                    MessageBox.Show("Please fill out all required fields.");
                    return;
                }

                RegisterRequest request = new RegisterRequest();

                request.Username = txtUsername.Text;
                request.Password = txtPassword.Text;
                request.FullName = txtFullName.Text;
                request.Email = txtEmail.Text;
                request.Phone = txtPhone.Text;

                await api.PostAsync("/auth/register", request);

                MessageBox.Show("Registration successful. You can now log in.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
