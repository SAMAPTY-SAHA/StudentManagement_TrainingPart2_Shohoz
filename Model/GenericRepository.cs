using MongoDB.Bson;
using MongoDB.Driver;
using StudentManagement_asp.netWebApi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement_asp.netWebApi_.Models
{     
    public class GenericRepository : IRepository
    {

        //private IMongoCollection collection;
        private IMongoClient client;
        private IMongoDatabase database;

        //IDataBaseSettings _databaseSettings;


       /* public static MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase database = dbClient.GetDatabase("MongoDBPractice");
        IMongoCollection<Student> collection = database.GetCollection<Student>("MongoDBPractice");
        */
        public GenericRepository()
        {
            //_databaseSettings = settings;
            // client = new MongoClient(settings.ConnectionString);
            //database = client.GetDatabase(settings.DatabaseName);
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("MongoDBPractice");
            //collection = database.GetCollection<T>("Students");


        }
        //public MockStudentRepository()
        //{
        //    client = new MongoClient(_databaseSettings.ConnectionString);
        //    database = client.GetDatabase(_databaseSettings.DatabaseName);

        //}
        

        public T Delete<T>(string id)
        {
            String table = typeof(T).Name;
            IMongoCollection<T> collection = database.GetCollection<T>(table + "s");
            var filter = Builders<T>.Filter.Eq("ID", id);
            var record = collection.FindOneAndDelete(filter);
            return record;
        }

        public IEnumerable<T> GetAll<T>()
        {
            string table = typeof(T).Name;
            IMongoCollection<T> collection = database.GetCollection<T>(table + "s");
            var all = collection.Find(new BsonDocument());
            return all.ToEnumerable();
        }

        public T GetById<T>(string id)
        {
           String table = typeof(T).Name;
            IMongoCollection<T> collection = database.GetCollection<T>(table + "s");
            /*var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).FirstOrDefault();*/
            var filter = Builders<T>.Filter.Eq("ID", id);
            return collection.Find(filter).FirstOrDefault();
        }

        public T Insert<T>(T record)
        {
              String table = typeof(T).Name;
            IMongoCollection<T> collection = database.GetCollection<T>(table + "s");

             collection.InsertOne(record);

             return record;
            
        }

        public T Update<T>(T record, string id)
        {
           String table = typeof(T).Name;
            IMongoCollection<T> collection = database.GetCollection<T>(table + "s");
            var filter = Builders<T>.Filter.Eq("ID", id);
            var updated = collection.ReplaceOne(filter, record);
            return record;
        }
        /* public Student Add(T student)
{
   /* student.ID = _studentList.Max(e => e.ID) + 1;
    _studentList.Add(student);*/
        // return student;
        /*  }

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
          }*/
    }
}
