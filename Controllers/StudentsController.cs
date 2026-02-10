using Day2.DTO;
using Day2.Models;
using Day2.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Day2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        GenericRepository<student> repo;
        public StudentsController(GenericRepository<student> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult GetAllStudents ()
        {
            //var students = db.students.ToList();
            //return Ok(students);
            /*return Ok(db.students.ToList());*/

            List<student> stds = repo.SelectAll();
            List<studentDTO> stdsdto = new List<studentDTO>();
            foreach(student s in stds)
            {
                studentDTO sd = new studentDTO()
                {
                    StudetnName = s.Name,
                    StudetnAge = s.age +1 ,
                    StudetnDeptid = s.deptid ?? 0,
                };

                stdsdto.Add(sd);
            }
            return Ok(stdsdto);

        }

        [HttpGet("{id}")]
        [Produces("application/json", "application/xml")]
        public ActionResult GetStudentByID (int id)
        {
            var Student = repo.SelectById(id);
            if (Student == null)
                return NotFound("No Student with ID"  + id);
            else
            /*return Ok(Student);*/
            {
                studentDTO stdo = new studentDTO();
                {
                    stdo.StudetnName = Student.Name;
                    stdo.StudetnAge = Student.age ;
                    stdo.StudetnDeptid = Student.deptid ?? 0;
                }
                return Ok(stdo); 
            }
            
        }


        [HttpPost("{id}")]
        [Consumes("application/json")]//this will allow only json requests
        public ActionResult AddStudent(student s,int id)
        {
            repo.AddOne(s);
            repo.SaveChange();
            return Ok();
        }

        


    }
}
