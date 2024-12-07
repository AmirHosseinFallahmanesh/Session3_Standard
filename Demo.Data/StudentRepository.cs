using Demo.EF;
using Demo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data
{
    public class StudentRepository
    {
        private readonly DemoContext context;

        public StudentRepository(DemoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetStudent(Guid id)
        {
            return context.Students.Find(id);
        }


        public IEnumerable<Student> GetAllActiveStudents()
        {
            return context.Students.Where(a=>a.Active).ToList();
        }


        public Guid Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();

            return student.StudentId;
        }

        public Student Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
            return student;
        }

        public void Remove(Guid id)
        {
            context.Students.Remove(new Student() { StudentId = id });
            context.SaveChanges();

        }
    }
}
