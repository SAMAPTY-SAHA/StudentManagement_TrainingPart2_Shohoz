using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_asp.netWebApi_.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        // public int ID { get; set; }
        public string ID { get; set; }

        public string name { get; set; }
        public string department { get; set; }

    }
}
