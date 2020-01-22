using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_asp.netWebApi_.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;
        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student() {ID=1,name="puja",department="SWE"},
                new Student() {ID=2,name="Mira",department="SWE"},
                new Student() {ID=3,name="Maya",department="SWE"},

            };
        }
        public Student Add(Student student)
        {
            student.ID = _studentList.Max(e => e.ID) + 1;
            _studentList.Add(student);
            return student;
        }

        public void delete(Student newSt)
        {
            _studentList.Remove(newSt);
        }

        public IEnumerable<Student> getAllStudent()
        {
            return _studentList;
        }

        public Student GetStudent(int ID)
        {
            return _studentList.FirstOrDefault(e => e.ID == ID);
        }

        public Student update(Student student)
        {
            Student st = _studentList.FirstOrDefault(e => e.ID == student.ID);
            int idx = _studentList.IndexOf(st);
            _studentList[idx] = student;
            return student;
        }
    }
}
