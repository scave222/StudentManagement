using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ServiceRepository
{
    public class StudentRepository : IStudent
    {
        private readonly DataContext context;
        public StudentRepository(DataContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Student> Students
        {
            get
            {
                return context.StudentTable;
            }
        }

        //Add student to data base
        public void AddStudent(Student student)
        {

            context.StudentTable.Add(student);
            context.SaveChanges();
        }

        //Delete student to data base
        public Student Delete(long Id)
        {
            Student stud = context.StudentTable.Find(Id);
            if (stud != null)
            {
                context.StudentTable.Remove(stud);
                context.SaveChanges();
            }

            return stud;

        }
        public Student GetStudent(long Id)
        {
            return context.StudentTable.Find(Id);
        }

        //Edit student to data base
        public void EditStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();

        }

        //Search student from data base
       public IQueryable<Student> Search(string SName)
        {
            var employee = context.StudentTable.Where(s => s.Surname.Contains(SName) || s.Email.Contains(SName) || s.PhoneNumber.Contains(SName));
            return employee;

        }
    }
}
