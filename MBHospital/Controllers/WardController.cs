using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBHospital.Controllers
{

    [ApiController]
    [Route("ward")]
    public class WardController : ControllerBase
    {
        private readonly IServiceRepository<Ward, int> wardRepository;

        public WardController(IServiceRepository<Ward, int> wardRepository)
        {
            this.wardRepository = wardRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = wardRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = wardRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Ward entity)
        {
            var response = wardRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Ward entity)
        {
            var response = wardRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = wardRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}