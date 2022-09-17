using MBHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MBHospital.Controllers
{
    [ApiController]
    [Route("nurse")]
    public class NurseController : Controller
    {
        private readonly IServiceRepository<Nurse, int> NurseRepository;

        public NurseController(IServiceRepository<Nurse, int> NurseRepository)
        {
            this.NurseRepository = NurseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = NurseRepository.GetRecords();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = NurseRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Nurse entity)
        {
            var response = NurseRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Nurse entity)
        {
            var response = NurseRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = NurseRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}
