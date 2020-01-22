using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_asp.netWebApi_.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int ID);
        IEnumerable<Student> getAllStudent();
        Student Add(Student student);
        void delete(Student newSt);
        Student update(Student student);
    }
}
