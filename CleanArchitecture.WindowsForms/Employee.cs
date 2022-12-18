using CleanArchitecture.Business.DTOs;
using CleanArchitecture.Business.Interfaces;
using CleanArchitecture.Business.Services;
using Microsoft.VisualBasic;

namespace CleanArchitecture.WindowsForms
{
    public partial class Employee : Form
    {
        private readonly IEmployeeService _employeeService;
        private string Id = string.Empty;

        public Employee()
        {
            InitializeComponent();

            try
            {
                _employeeService = new EmployeeService();
                EmployeeListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        public async void EmployeeListAsync()
        {
            var employees = await _employeeService.Get();
            EmployeeView.DataSource = employees;
        }

        private async void AddEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeName.Text) || string.IsNullOrEmpty(EmployeeAge.Text))
            {
                MessageBox.Show("Name Or Age Cannot be Empty");
            }
            else
            {
                var employee = new Business.DTOs.EmployeeDTO()
                {
                    Name = EmployeeName.Text,
                    Age = int.Parse(EmployeeAge.Text),
                    Gender = EmployeeGender.Text
                };

                await _employeeService.Add(employee);

                MessageBox.Show("Employee Added");

                EmployeeListAsync();
            }
        }

        private async void EmployeeUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Interaction.InputBox("INPUT", "INPUT ID TO UPDATE RECORD");
            }

            if (!Id.All(char.IsDigit) || string.IsNullOrEmpty(EmployeeName.Text) || string.IsNullOrEmpty(EmployeeAge.Text))
            {
                MessageBox.Show("Invalid Id, Name Or Age");
            }
            else
            {
                var employee = new EmployeeDTO
                {
                    Id = int.Parse(Id),
                    Name = EmployeeName.Text,
                    Age = int.Parse(EmployeeAge.Text),
                    Gender = EmployeeGender.Text
                };

                await _employeeService.Update(employee);

                MessageBox.Show("Employee Updated");

                EmployeeListAsync();
            }
        }

        private void EmployeeAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void EmployeeDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Id))
            {
                string Id = Interaction.InputBox("INPUT", "INPUT ID TO UPDATE RECORD");
            }

            if (Id.All(char.IsDigit))
            {
                var exist = _employeeService.Get(int.Parse(Id)).Result;

                if (exist.Id != 0)
                {
                    await _employeeService.Delete(new EmployeeDTO { Id = int.Parse(Id) });

                    EmployeeListAsync();
                }
                else
                {
                    MessageBox.Show("Id doesn't exist");
                }
            }
            else
            {
                MessageBox.Show("Invalid Id");
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Id = EmployeeView.CurrentRow.Cells[0].Value.ToString();
            EmployeeName.Text = EmployeeView.CurrentRow.Cells[1].Value.ToString();
            EmployeeAge.Text = EmployeeView.CurrentRow.Cells[2].Value.ToString();
            EmployeeGender.Text = EmployeeView.CurrentRow.Cells[3].Value.ToString();
        }
    }
}