using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBHospital.Controllers
{

    [ApiController]
    [Route("wardboy")]
    public class WardboyController : ControllerBase
    {
        private readonly IServiceRepository<Wardboy, int> wardboyRepository;

        public WardboyController(IServiceRepository<Wardboy, int> wardboyRepository)
        {
            this.wardboyRepository = wardboyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = wardboyRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = wardboyRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Wardboy entity)
        {
            var response = wardboyRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Wardboy entity)
        {
            var response = wardboyRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = wardboyRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}