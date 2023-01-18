using NttData.FileManagement.Common.Model;
using NttData.FileManagement.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttData.FileManagement.DataAccess.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        public bool Add(Student student)
        {
            File.AppendAllText(@"E:\Formacion\Proyectos\NttData.FileManagement\NttData.FileManagement.Presentation.WinSite\bin\Debug\File.txt", student.ToString() + "\n");
            return true;
        }
    }
}
