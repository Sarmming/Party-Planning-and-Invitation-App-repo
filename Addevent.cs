
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EventPlanner.Models
{
    public class Addevent
    {
        [PrimaryKey, AutoIncrement]
        public int EID { get; set; }

        public string Name { get; set; }
        public string ename{ get; set; }
        public string evenue{ get; set; }
        public string etype { get; set; }
        public string gcon { get; set; }
        public string eguest { get; set; }
               public string etime { get; set; }
        public  string edate { get; set; }
        public string hall { get; set; }
        public string food { get; set; }
        public string artist { get; set; }
       public string  mc{ get; set; }
        public string tras{ get; set; }
        public string deco { get; set; }
        public string ch { get; set; }
        public string total{ get; set; }







    }
}
