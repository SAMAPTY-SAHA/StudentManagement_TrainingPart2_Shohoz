using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement_asp.netWebApi_.Models
{
    public class DataBaseSettings : IDataBaseSettings
    {
        //string BooksCollectionName { get; set; }
        //public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }


        public interface IDataBaseSettings
        {
            //string CollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
}

