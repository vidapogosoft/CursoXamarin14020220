using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;


namespace BDSQLite1
{
    public class StudDB
    {

        readonly SQLiteAsyncConnection database;

        public StudDB(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Student>().Wait();
        }

        //Retorna todos los estudiantes (list view)
        public Task<List<Student>> GetStudentsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }

        //Retorna un estudiante seleccionado de la lista (EditStudent)
        public Task<Student> GetStudentAsync(int id)
        {
            return database.Table<Student>().Where(i => i.stdid == id).FirstOrDefaultAsync();
        }

        //Registro de datos
        public Task<int> SaveStudentAsync(Student stud)
        {
            return database.InsertAsync(stud);
        }

        //Actualizacion de datos
        public Task<int> UpdateStudentAsync(Student stud)
        {
            return database.UpdateAsync(stud);
        }

        //Delete
        public Task<int> DelStudentAsync(Student stud)
        {
            return database.DeleteAsync(stud);
        }
    }
}
