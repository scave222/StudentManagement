using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ServiceRepository
{
    public interface IStudent
    {
        IEnumerable<Student> Students { get; }
        public void AddStudent(Student student);

        Student Delete(long Id);
        Student GetStudent(long Id);
        void EditStudent(Student student);

        IQueryable<Student> Search(string SName);
    }
}
