
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SQLite;
using Xamarin.Forms.PlatformConfiguration;
using System.IO;
using CloudKit;

namespace EventPlanner.Models
{

    public class dbsql
    {
      
        int mxrow;
        public static string dbpath, response;
        
                public static void create_user_table(){
           dbpath =(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));

            //Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
            var db = new SQLiteConnection(dbpath);
            try
            {
                db.CreateTable<Person>();
               db.CreateTable<Addevent>();
                response = ("sucessful");

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
           
        }

        public static void create_user_table2()
        {
           

        }


    }
}
