using NttData.FileManagement.Business.Logic.Contracts;
using NttData.FileManagement.Business.Logic.Implementations;
using NttData.FileManagement.Common.Model;
using System;
using System.Windows.Forms;

namespace NttData.FileManagement.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IStudentService studentService= new StudentService();
            Student student = new Student();

            studentService.Add(student);
            student.Id = int.Parse(txtId.Text);
            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            //student.Birthday = txtBirthday.Text.ToString("dd/MM/yyyy");

            MessageBox.Show("The student is saved");
        }
    }
}
