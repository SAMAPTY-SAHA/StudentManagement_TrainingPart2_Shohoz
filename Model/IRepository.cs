using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_asp.netWebApi_.Models
{
    public interface IRepository
    {
        /*Student GetStudent(int ID);
        IEnumerable<Student> getAllStudent();
        Student Add(Student student);
        void delete(Student newSt);
        Student update(Student student);*/
        IEnumerable<T> GetAll<T>();
        T GetById<T>(string id);
        T Insert<T>(T record);
        T Delete<T>(string id);
        T Update<T>(T record, string id);
    }
}
