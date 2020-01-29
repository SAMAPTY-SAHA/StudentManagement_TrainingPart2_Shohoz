using StudentManagement_asp.netWebApi_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IStudentService
    {
        Student GetStudent(string ID);
         IEnumerable<Student> getAllStudent();
         Student Add(Student student);
        //void delete(Student newSt);
        void delete(String id);
         Student update(Student student,string id);
        
    }
}
