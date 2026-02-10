using Day2.Models;

namespace Day2.Repository
{
    public class GenericRepository <Tentinty> where Tentinty : class
    {
        ITIContext db;

        public GenericRepository(ITIContext db)
        {
            this.db = db;
        }

        public List<Tentinty> SelectAll()
        { 
        return db.Set<Tentinty>().ToList();
        }


        public Tentinty SelectById(int id)
        {
            return db.Set<Tentinty>().Find(id);
        }

        public void AddOne(Tentinty t)
        {
             db.Set<Tentinty>().Add(t);
        }

        public void SaveChange()
        {
            db.SaveChanges();

        }

    }
}
