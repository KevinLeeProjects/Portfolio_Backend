using Microsoft.AspNetCore.Mvc;
using Portfolio_Backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio_Backend.Controllers
{
    [Route("/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DBHelper _db;
        private readonly CreateNewProject _cnp;
        private readonly GetProjects _gp;
        DatabaseHelper _dbHelper = new DatabaseHelper();

        public AdminController(EF_DataContext ef_dataContext)
        {
            _db = new DBHelper(ef_dataContext, _dbHelper);
            _cnp = new CreateNewProject(ef_dataContext, _dbHelper);
            _gp = new GetProjects(ef_dataContext, _dbHelper);
        }

        // GET /getProjects
        [HttpGet]
        [Route("getProjects")]
        public IActionResult Get()
        {
            
            try
            {
                IEnumerable<ProjectModel> data = _gp.GetAllProjects();

                if(data.Any())
                {
                    Console.WriteLine(data);
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdminController>/5
        [HttpGet]
        //[Route("api/get")]
        public string Get(int id)
        {
            return "Kevin Lee Backend";
        }

        // POST /admin
        [HttpPost]
        [Route("admin")]
        public IActionResult Post([FromBody] LoginModel model)
        {
            
            try
            {
                if(_db.CheckLogin(model))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST /addProject
        [HttpPost]
        [Route("addProject")]
        public IActionResult Post([FromBody] ProjectModel projects)
        {
            try
            {
                Console.WriteLine("Projects1");
                if (_cnp.AddProject(projects))
                {
                    Console.WriteLine("Projects");
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        //[Route("api/put")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        //[Route("api/delete")]
        public void Delete(int id)
        {
        }
    }
}
