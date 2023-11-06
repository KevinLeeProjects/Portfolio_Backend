using Microsoft.AspNetCore.Mvc;
using Portfolio_Backend.EFCore;
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
        private readonly CreateNewGame _cng;
        private readonly GetGames _gg;
        private readonly CreatePortfolio _cp;
        private readonly GetPortfolio _getPortfolio;
        DatabaseHelper _dbHelper = new DatabaseHelper();

        public AdminController(EF_DataContext ef_dataContext)
        {
            _db = new DBHelper(ef_dataContext, _dbHelper);
            _cnp = new CreateNewProject(ef_dataContext, _dbHelper);
            _gp = new GetProjects(ef_dataContext, _dbHelper);
            _cng = new CreateNewGame(ef_dataContext, _dbHelper);
            _gg = new GetGames(ef_dataContext, _dbHelper);
            _cp = new CreatePortfolio(ef_dataContext, _dbHelper);
            _getPortfolio = new GetPortfolio(ef_dataContext, _dbHelper);
        }

        // GET /getProjects
        [HttpGet]
        [Route("getProjects")]
        public IActionResult GetProjects()
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

        //GET /getGames
        [HttpGet]
        [Route("getGames")]
        public IActionResult GetGames()
        {
            try
            {
                IEnumerable<GameModel> data = _gg.GetAllGames();

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
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
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
                if (_cnp.AddProject(projects))
                {
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

        //POST /addGame
        [HttpPost]
        [Route("addGame")]
        public IActionResult Post([FromBody] GameModel games)
        {
            try
            {
                if (_cng.AddGame(games))
                {
                    Console.WriteLine("Here");
                    return Ok();
                }
                else
                {
                    Console.WriteLine("Here1");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //POST /addProject/Portfolio
        [HttpPost]
        [Route("addProject/Portfolio")]
        public IActionResult Post([FromBody] PortfolioModel portfolio)
        {
            Console.WriteLine("Here3");
            try
            {
                if (_cp.AddPortfolio(portfolio))
                {
                    Console.WriteLine("Here");
                    return Ok();
                }
                else
                {
                    Console.WriteLine("Here1");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Here4");
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //GET /getProject/Portfolio
        [HttpGet]
        [Route("getProject/Portfolio")]
        public IActionResult GetPortfolio()
        {
            Console.WriteLine("here");
            try
            {
                IEnumerable<PortfolioModel> data = _getPortfolio.GetPortfolioInfo();

                if (data.Any())
                {
                    Console.WriteLine(data);
                    return Ok(data);
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
