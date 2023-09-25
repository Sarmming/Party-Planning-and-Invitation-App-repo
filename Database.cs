using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Person>().Wait();
            _database.CreateTableAsync<Addevent>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return _database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return _database.InsertAsync(person);
        }
        public Task<int> SaveEvent(Addevent adevent)
        {
            return _database.InsertAsync(adevent);
        }

        public Task<List<Addevent>> GetEvent()
        {
            return _database.Table<Addevent>().ToListAsync();
        }
    }
    }
