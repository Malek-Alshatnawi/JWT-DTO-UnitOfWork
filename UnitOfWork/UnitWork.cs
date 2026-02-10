using Day2.Models;
using Day2.Repository;

namespace Day2.UnitOfWork
{
    public class UnitWork
    {

        ITIContext db;
        public  GenericRepository<student> studentrepo;
        public  GenericRepository<Department> departmentrepo;

        public UnitWork (ITIContext db)
        {
            this.db = db;

            /* HERE IF WE NOTICED WE'RE CREATE AN OBJECT OF THE BELOW 2 
             * REPOS EACH TIME WE ARE CALLING THE CONSTRUCTRE WHICH LEAD 
             * TO A HUGE LOAD IN CASE WE'VE MANY TABLE, SO!! TO AVOID SUCH CASES
             * WE'RE GONNA TO IMPLEMENT 2 METHODS TO INVOKE EACH REPOS WHEN NEEDED*/
             //studentrepo = new  GenericRepository<student>(db);
             //departmentrepo = new GenericRepository<Department>(db);
        }


        public GenericRepository<student> StdRepo
        {
            get { 

                if (studentrepo == null)
                studentrepo = new GenericRepository<student>(db);
                return studentrepo;
            }
        }

        public GenericRepository<Department> DepRepo
        {
            get
            {

                if (departmentrepo == null)
                    departmentrepo = new GenericRepository<Department>(db);
                return departmentrepo;
            }
        }


        public void SaveChange()
        {
            db.SaveChanges();
        }   


    }
}
