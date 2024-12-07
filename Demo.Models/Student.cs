using System;

namespace Demo.Models
{
    public class Student
    {
        public Student()
        {
            StudentId = Guid.NewGuid();
            Active = true;
        }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
    }
}
