using Application.Entities;
using MBHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MBHospital.Controllers
{
    [ApiController]
    [Route("otherservices")]
    public class OtherServicesController : Controller
    {
        private readonly IServiceRepository<Other_Services, int> OtherServicesRepository;

        public OtherServicesController(IServiceRepository<Other_Services, int> OtherServicesRepository)
        {
            this.OtherServicesRepository = OtherServicesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = OtherServicesRepository.GetRecords();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = OtherServicesRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Other_Services entity)
        {
            var response = OtherServicesRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Other_Services entity)
        {
            var response = OtherServicesRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = OtherServicesRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}
