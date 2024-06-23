using AdityaAPI.Models;
using AdityaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdityaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<City> _cityRepository;
        public AccountController(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        //public IActionResult GetCities()
        //{
        //    var Response = _cityRepository.GetAll();
        //    return Ok(Response);
        //}

        //public IActionResult GetAll(string tableName, string storedProcedureName)
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var tableName = "City";
                var storedProcedureName = "usp_GetCities";
                var result = _cityRepository.GetAll(tableName, storedProcedureName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
    }
}
