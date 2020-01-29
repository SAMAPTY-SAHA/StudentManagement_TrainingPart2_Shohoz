using StudentManagement_asp.netWebApi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
   public  class StudentService : IStudentService
    {

        // MockStudentRepository<Student> _mockStudent = new MockStudentRepository<Student>();
        IRepository _mockStudent;
        public StudentService(IRepository mockStudent)
        {
            _mockStudent = mockStudent;

        }

        

        public Student Add(Student student)
        {
            _mockStudent.Insert(student);
            return student;
        }

        public void delete(string id)
        {
            _mockStudent.Delete<Student>(id);

        }

        public IEnumerable<Student> getAllStudent()
        {
            return _mockStudent.GetAll<Student>();
        }

        public Student GetStudent(string ID)
        {
            //return _studentList.FirstOrDefault(e => e.ID == ID);
            return _mockStudent.GetById<Student>(ID);
        }

        public Student update(Student student,string id)
        {
            _mockStudent.Update(student,id);
            return student;
        }
    }
}
