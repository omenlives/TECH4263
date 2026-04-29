using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using StudentDashboard1.Models;
using System.Text.Json;
using System.Net.Http.Json;

namespace StudentDashboard1;
public partial class MainForm : Form
{
    // Single shared HttpClient — never create one per request
    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:5001") // update to your API port
    };

    // In-memory list — keeps the ListBox and detail panel in sync
    private List<StudentResponseDto> _students = new();

    public MainForm()
    {
        InitializeComponent();
        _ = LoadStudentsAsync();   // load on startup
    }

    private async Task LoadStudentsAsync()
    {
        try
        {
            SetStatus("Loading...", Color.Gray);

            var response = await _httpClient.GetAsync("/students");

            if (!response.IsSuccessStatusCode)
            {
                SetStatus($"Error: {response.StatusCode}", Color.Red);
                return;
            }

            string json = await response.Content.ReadAsStringAsync();

            _students = JsonSerializer.Deserialize<List<StudentResponseDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<StudentResponseDto>();

            lstStudents.Items.Clear();
            foreach (var s in _students)
                lstStudents.Items.Add(s.Name);

            SetStatus(_students.Count > 0 ? "" : "No students found.", Color.Gray);
        }
        catch (HttpRequestException)
        {
            SetStatus("Cannot connect to StudentAPI. Is it running?", Color.Red);
        }
    }
    private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = lstStudents.SelectedIndex;

        if (index < 0 || index >= _students.Count)
        {
            lblNoSelection.Visible = true;
            pnlDetailFields.Visible = false;
            return;
        }

        var student = _students[index];

        lblIdValue.Text = student.Id.ToString();
        lblNameValue.Text = student.Name;
        lblMajorValue.Text = student.Major;

        lblNoSelection.Visible = false;
        pnlDetailFields.Visible = true;
    }
    private async void btnCreate_Click(object sender, EventArgs e)
    {
        // 1. Validate
        string name = txtName.Text.Trim();
        string major = txtMajor.Text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            SetStatus("Name is required.", Color.OrangeRed);
            txtName.Focus();
            return;
        }
        if (!int.TryParse(txtAge.Text.Trim(), out int age) || age <= 0)
        {
            SetStatus("Age must be a positive number.", Color.OrangeRed);
            txtAge.Focus();
            return;
        }
        if (string.IsNullOrEmpty(major))
        {
            SetStatus("Major is required.", Color.OrangeRed);
            txtMajor.Focus();
            return;
        }

        // 2. Build DTO
        var dto = new CreateStudentDto { Name = name, Age = age, Major = major };

        try
        {
            btnCreate.Enabled = false;
            SetStatus("Creating...", Color.Gray);

            // 3. POST to API
            var response = await _httpClient.PostAsJsonAsync("/students", dto);

            if (response.IsSuccessStatusCode)
            {
                // 4. Clear inputs
                txtName.Clear();
                txtAge.Clear();
                txtMajor.Clear();

                SetStatus($"Student '{name}' created successfully.", Color.SeaGreen);

                // 5. Refresh the list
                await LoadStudentsAsync();
            }
            else
            {
                SetStatus($"Failed: {response.StatusCode}", Color.Red);
            }
        }
        catch (HttpRequestException)
        {
            SetStatus("Cannot connect to StudentAPI.", Color.Red);
        }
        finally
        {
            btnCreate.Enabled = true;
        }
    }
    private void SetStatus(string message, Color color)
    {
        lblStatus.Text = message;
        lblStatus.ForeColor = color;
    }
}
