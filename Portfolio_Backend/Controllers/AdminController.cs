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
        public AdminController(EF_DataContext ef_dataContext)
        {
            _db = new DBHelper(ef_dataContext);
        }
        // GET: api/<AdminController>
        [HttpGet]
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        //[Route("api/get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        [Route("admin")]
        public IActionResult Post([FromBody] LoginModel model)
        {
            Console.WriteLine("Admin");
            try
            {
                return Ok(_db.CheckLogin(model));
            }
            catch (Exception ex)
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
