using Microsoft.VisualStudio.TestTools.UnitTesting;
using NttData.FileManagement.Common.Model;
using NttData.FileManagement.DataAccess.Repository.Contracts;
using NttData.FileManagement.DataAccess.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttData.FileManagement.DataAccess.Repository.Implementations.Implementations.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Student student1= new Student();
            Student student2 = new Student();

            student1.Id = 1;
            student1.Name = "Juan";
            student1.Surname = "Soto";
            student1.Birthday = DateTime.Parse("18/05/1996");
            student1.Age = 28;

            IStudentRepository studentRepository = new StudentRepository();

            Assert.IsTrue(studentRepository.Add(student1));

            var path = @ConfigurationManager.AppSettings.Get("StudentsFilePath");

            using (FileStream aFile = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(student1.ToString());
            }

            student2 = ReadStudent(path);

            Assert.AreEqual(student1, student2);

            File.Delete(@ConfigurationManager.AppSettings.Get("StudentsFilePath"));

            Assert.IsTrue(!File.Exists(@ConfigurationManager.AppSettings.Get("StudentsFilePath")));
        }

        private Student ReadStudent(string path)
        {
            Student student = new Student();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                if ((line = sr.ReadLine()) != null)
                {
                    string[] array = line.Split(',');

                    student = new Student()
                    {
                        Id = int.Parse(array[0]),
                        Name = array[1],
                        Surname = array[2],
                        Birthday = DateTime.Parse(array[3]),
                        Age = int.Parse(array[4])
                    };
                }
            }

            return student;
        }
    }
}