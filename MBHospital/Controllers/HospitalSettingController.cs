using MBHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MBHospital.Controllers
{
    [ApiController]
    [Route("hospitalsetting")]
    public class HospitalSettingController : Controller
    {
        private readonly IServiceRepository<Hospital_Setting, int> HospitalSettingRepository;

        public HospitalSettingController(IServiceRepository<Hospital_Setting, int> HospitalSettingRepository)
        {
            this.HospitalSettingRepository = HospitalSettingRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = HospitalSettingRepository.GetRecords();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = HospitalSettingRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Hospital_Setting entity)
        {
            var response = HospitalSettingRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Hospital_Setting entity)
        {
            var response = HospitalSettingRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = HospitalSettingRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}
