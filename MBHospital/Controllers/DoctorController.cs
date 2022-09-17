using MBHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MBHospital.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : Controller
    {
        private readonly IServiceRepository<Doctor, int> doctorRepository;

        public DoctorController(IServiceRepository<Doctor, int> doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = doctorRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = doctorRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Doctor entity)
        {
            var response = doctorRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Doctor entity)
        {
            var response = doctorRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = doctorRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}
