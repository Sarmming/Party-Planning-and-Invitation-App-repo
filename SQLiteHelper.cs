
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace EventPlanner.Models
{
    public class SQLiteHelper
    {
        
     string  dbpath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
        //(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
        public string Response;
      
        public void savedata(string sql)
        {
                        using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(dbpath))
            {
                SQLite.SQLiteCommand com = new SQLite.SQLiteCommand(con);
                //com = con.CreateCommand("UPDATE JDictTable WHERE ID == ? SET isFavorite = '?'", id_, true);
                com.CommandText = sql;
                // "UPDATE JDictTable SET isFavorite ='" + true + "' WHERE ID = '" + id_ + "'";
                com.ExecuteNonQuery();
                Response   ="added";
                con.Close();
            }
        }
  public void get_data(string sql)
        {

            using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(dbpath))
            {
                SQLite.SQLiteCommand com = new SQLite.SQLiteCommand(con);
                //com = con.CreateCommand("UPDATE JDictTable WHERE ID == ? SET isFavorite = '?'", id_, true);
                com.CommandText = sql;
               int  i = Convert.ToInt32(com.ExecuteNonQuery());
                if (i <= 0)
                {
                   
                    Response = "nill";
                }
                else
                {
                    Response = ("found");
                }



            }


        }


    }
}
