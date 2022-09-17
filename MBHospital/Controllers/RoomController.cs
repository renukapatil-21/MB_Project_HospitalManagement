using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBHospital.Controllers
{

    [ApiController]
    [Route("room")]
    public class RoomController : ControllerBase
    {
        private readonly IServiceRepository<Room, int> roomRepository;

        public RoomController(IServiceRepository<Room, int> roomRepository)
        {
            this.roomRepository =roomRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = roomRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = roomRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Room entity)
        {
            var response = roomRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Room entity)
        {
            var response = roomRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = roomRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}