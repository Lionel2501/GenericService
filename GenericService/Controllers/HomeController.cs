using GenericService.Models;
using GenericService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // private readonly DatabaseContext _databaseContext;
        private readonly IGenericRepository<Persons> _PersonsRepo;
        private readonly IGenericRepository<Ciudades> _CiudadesRepo;
        private readonly IGenericRepository<Direcciones> _DireccionesRepo;

        public HomeController(IGenericRepository<Persons> personsRepo, IGenericRepository<Ciudades> ciudadesRepo, IGenericRepository<Direcciones> direccionesRepo)
        {
            _PersonsRepo = personsRepo;
            _CiudadesRepo = ciudadesRepo;
            _DireccionesRepo = direccionesRepo;
        }

        [HttpPost("AddPersons")]
        public IActionResult AddPersons([FromBody] Persons person)
        {
            var _person = person;
            _PersonsRepo.Add(_person);
            return Ok(true);
        }

        [HttpPost("AddCiudades")]
        public IActionResult AddCiudades([FromBody] Ciudades ciudades)
        {
            _CiudadesRepo.Add(ciudades);
            return Ok(true);
        }

        [HttpPost("AddDirecciones")]
        public IActionResult AddDirecciones([FromBody] Direcciones direcciones)
        {
            _DireccionesRepo.Add(direcciones);
            return Ok(true);
        }

        [HttpGet(Name = "GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var persons = _PersonsRepo.GetAll();
            return Ok(persons);
        }
        /*
        [HttpGet(Name = "GetAllCiudades")]
        public IActionResult GetAllCiudades()
        {
            var ciudades = _CiudadesRepo.GetAll();
            return Ok(ciudades);
        }

        [HttpGet(Name = "GetAllDirecciones")]
        public IActionResult GetAllDirecciones()

        {
            var direcciones = _DireccionesRepo.GetAll();
            return Ok(direcciones);
        }
        */

    }
}
