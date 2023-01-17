using NttData.FileManagement.Business.Logic.Contracts;
using NttData.FileManagement.Common.Model;
using NttData.FileManagement.DataAccess.Repository.Contracts;
using NttData.FileManagement.DataAccess.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttData.FileManagement.Business.Logic.Implementations
{
    public class StudentService : IStudentService
    {
        public bool Add(Student student)
        {
            CalculaEdad(student);
            IStudentRepository studentRepository = new StudentRepository();
            studentRepository.Add(student);
            return true;
        }

        void CalculaEdad(Student student)
        {
            var Ahora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var Nacimiento = new DateTime(student.Birthday.Year, student.Birthday.Month, student.Birthday.Day);
            var edad = ((Ahora - Nacimiento).Days / 365);
            student.Age = edad;
        }
    }
}
