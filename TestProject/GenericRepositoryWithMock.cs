using StudentManagement_asp.netWebApi_.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using System.Linq;
using MongoDB.Bson;

namespace TestProject
{
    public class GenericRepositoryWithMock
    {
        private readonly IRepository MockRepository;      
        private IList<Student> _studentList;
        public GenericRepositoryWithMock()
        {
             _studentList = new List<Student>()
             {
                new Student() {ID="1",name="puja",department="SWE"},
                new Student() {ID="2",name="Mira",department="SWE"},
                new Student() {ID="3",name="Maya",department="SWE"},

             };
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(e => e.GetById<Student>(
                  It.IsAny<string>())).Returns(
                (string id) => _studentList.Single(x => x.ID == id)
                );

            mockRepo.Setup(e => e.GetAll<Student>()).Returns(_studentList);

            mockRepo.Setup(e => e.Delete<Student>(It.IsAny<string>())).Returns(
                (string id) =>
                {
                    var tempStudent = _studentList.FirstOrDefault(e => e.ID == id);
                    _studentList.Remove(tempStudent);
                    return tempStudent;
                });


            mockRepo.Setup(e => e.Insert<Student>(It.IsAny<Student>())).Returns(
                (Student added) =>
                {
                    _studentList.Add(added);
                    return added;
                });





            this.MockRepository = mockRepo.Object;

        }
        

        [Fact]
        public void GetById_OK_Result()
        {
            var actual = this.MockRepository.GetById<Student>("1");
            //var GR = new GenericRepository();
            var expected = new Student { ID = "1", name = "puja", department = "SWE" };
            var actualjson = actual.ToJson();
            var expectedjson = expected.ToJson();
            Assert.Equal(expectedjson, actualjson);
        }
        [Fact]
        public void GetAll_Mock()
        {
            var actualStudents = this.MockRepository.GetAll<Student>();

            IList<Student>  expected = new List<Student>()
             {
                new Student() {ID="1",name="puja",department="SWE"},
                new Student() {ID="2",name="Mira",department="SWE"},
                new Student() {ID="3",name="Maya",department="SWE"},

             };
            var actualJson = actualStudents.ToJson();
            var expectedJson = expected.ToJson();
            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void Delete_Ok_Result()
        {
            // var GR = new GenericRepository();
            var actual = this.MockRepository.GetById<Student>("1");
            var  expected = new Student() { ID = "2", name = "Mira", department = "SWE" };
         
            var actualJson = actual.ToJson();
            var expectedJson = expected.ToJson();
            Assert.Equal(expectedJson, actualJson);
        }
        [Fact]
        public void Insert_Ok_Result()
        {
            //var GR = new GenericRepository();
            var student = new Student() { ID = "900", name = "Mimo", department = "SWE11" };
            var actual = this.MockRepository.Insert<Student>(student);
            var expected = student;
            var actualjson = actual.ToJson();
            var expectedjson = expected.ToJson();
            Assert.Equal(expectedjson, actualjson);

            // Assert.Equal(student, g);
        }
    }
}
