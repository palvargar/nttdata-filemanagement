﻿using NttData.FileManagement.Business.Logic.Contracts;
using NttData.FileManagement.Business.Logic.Implementations;
using NttData.FileManagement.Common.Model;
using System;
using System.Globalization;
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

            student.Id = int.Parse(txtId.Text);
            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            student.Birthday = DateTime.ParseExact(txtBirthday.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            studentService.Add(student);

            MessageBox.Show("The student is saved");
        }
    }
}