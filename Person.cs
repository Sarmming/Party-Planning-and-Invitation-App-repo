using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string nation { get; set; }
        public string password { get; set; }
    }
}
