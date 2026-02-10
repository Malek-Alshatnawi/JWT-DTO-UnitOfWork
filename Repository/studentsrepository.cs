using Day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Repository
{
    public class studentsrepository
    {
        ITIContext db = new ITIContext();
        public studentsrepository (ITIContext db)
        {
        this.db = db;
        }

        public List<student> SelectAllStudents()
        { 
        return db.students.ToList();
        }

        public student SelectStudentById (int id)
        {
            return db.students.Find(id);
        }

        public void  AddStudent (student s)
        {
            db.students.Add(s);
            //db.SaveChanges();
        }

        public void EditStudent (student s)
        {
            db.students.Update(s);
            //db.SaveChanges();
        }
        public void RemoveStudent(int s)
        {
            var studnet = db.students.Find(s);
            db.students.Remove(studnet);
            //db.SaveChanges();
        }

        public void SaveChange()
        {
            db.SaveChanges();
        }


    }
}
