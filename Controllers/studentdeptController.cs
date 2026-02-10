using Day2.Models;
using Day2.Repository;
using Day2.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentdeptController : ControllerBase
    {
        /*
         AS LONG AS WE USED UNITWORK THERE IS NO NNED TO USE THE BELOW TWO LINES 
        GenericRepository<student> studentrepos;
        GenericRepository<Department> departmentrepos;
        */
        UnitWork unit;


    public studentdeptController(UnitWork unit)
        {
            this.unit = unit;
        }

        [HttpPost]
        public ActionResult add(student s) {

            /*departmentrepos.SelectAll();
            studentrepos.SelectById(s.ID);
            studentrepos.AddOne(s);
            studentrepos.SaveChange();
            return Ok();*/

            ////////// the below is the unit of work format
            ///
            unit.DepRepo.SelectAll();
            unit.StdRepo.SelectById(s.ID);
            unit.StdRepo.AddOne(s);
            unit.SaveChange();
            return Ok();
        }



    }
}
