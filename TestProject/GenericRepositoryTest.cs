using MongoDB.Bson;
using StudentManagement_asp.netWebApi_.Models;
using System;
using Xunit;

namespace TestProject
{
    public class GenericRepositoryTest
    {
        [Fact]
        public void GetById_OK_Result()
        {
            var GR = new GenericRepository();
            var actual = GR.GetById<Student>("900");

            Student  expected = new Student { ID="600",name= "Moomoooo",department= "SWE11" };
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetById_Bad_Request()
        {
            var GR = new GenericRepository();
            var actual = GR.GetById<Student>("600");
            Student expected = new Student { ID = "6000", name = "Moomoooo", department = "SWE11" };
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Insert_Ok_Result()
        {
            var GR = new GenericRepository();
            Student student = new Student() { ID = "900", name = "Mimo", department = "SWE11" };
            var actual=GR.Insert<Student>(student);
            var expected = student;
            var actualjson = actual.ToJson();
            var expectedjson = expected.ToJson();
            Assert.Equal(expectedjson, actualjson);
            
           // Assert.Equal(student, g);
        }
        [Fact]
        public void Delete_Ok_Result()
        {
            var GR = new GenericRepository();
            Student student = new Student() { ID = "900", name = "Mimo", department = "SWE11" };
            var actual=GR.Delete<Student>("900");
            var expected = student;
            var actualJson = actual.ToJson();
            var expectedJson = actual.ToJson();
            Assert.Equal(expectedJson, actualJson);
        }
        [Fact]
        public void Delete_Bad_Result()
        {
            var GR = new GenericRepository();
            var actual = GR.GetById<Student>("900");
           // Student student = new Student() { ID = "900", name = "Mimo", department = "SWE11" };
            var expected = GR.Delete<Student>("000000");
           // var expected = ;
            var actualJson = actual.ToJson();
            var expectedJson =expected.ToJson();
            Assert.Equal(expectedJson, actualJson);
        }
        [Fact]
        public void Update_Ok_Result()
        {
            var GR = new GenericRepository();
            //var actual = GR.GetById<Student>("900");
            Student update = new Student() { ID = "900", name = "puja", department = "SWE11" };
            var expected = GR.Update<Student>(update, "900");
            // var expected = ;
            var actualJson = update.ToJson();
            var expectedJson = expected.ToJson();
            Assert.Equal(expectedJson, actualJson);
        }

    }
}
