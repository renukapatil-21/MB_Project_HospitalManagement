using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBHospital.Controllers
{

    [ApiController]
    [Route("patient_room")]
    public class PatientRoomController : ControllerBase
    {
        private readonly IServiceRepository<Patient_Room, int> patientroomRepository;

        public PatientRoomController(IServiceRepository<Patient_Room, int> patientroomRepository)
        {
            this.patientroomRepository = patientroomRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = patientroomRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = patientroomRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Patient_Room entity)
        {
            var response = patientroomRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient_Room entity)
        {
            var response = patientroomRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = patientroomRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}