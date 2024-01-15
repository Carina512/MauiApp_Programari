using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_Clinic.Models;

namespace Vet_Clinic.Data
{
    public class ProgramariDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramariDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
            _database.CreateTableAsync<Doctor>().Wait();
            
        }
        public SQLiteAsyncConnection GetConnection()
        {
            return _database;
        }

        // CRUD for appointments' table
        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }
        public Task<Appointment> GetAppointmentsAsync(int id)
        {
            return _database.Table<Appointment>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentAsync(Appointment alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> DeleteAppointmentAsync(Appointment alist)
        {
            return _database.DeleteAsync(alist);
        }

        // CRUD for doctors' table
        public Task<List<Doctor>> GetDoctorsAsync()
        {
            return _database.Table<Doctor>().ToListAsync();
        }
        public Task<Doctor> GetDoctorsAsync(int id)
        {
            return _database.Table<Doctor>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveDoctorAsync(Doctor dlist)
        {
            if (dlist.ID != 0)
            {
                return _database.UpdateAsync(dlist);
            }
            else
            {
                return _database.InsertAsync(dlist);
            }
        }
        public Task<int> DeleteDoctorAsync(Doctor dlist)
        {
            return _database.DeleteAsync(dlist);
        }

        // CRUD for invoices' table
       

       
    }
}
