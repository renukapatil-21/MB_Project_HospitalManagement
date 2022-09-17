using MBHospital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MBHospital.Controllers
{
    [ApiController]
    [Route("doctorpatientvisit")]
    public class DoctorPatientVisitController : Controller
    {
        private readonly IServiceRepository<Doctor_Patient_Visit, int> DoctorPatientVisitRepository;

        public DoctorPatientVisitController(IServiceRepository<Doctor_Patient_Visit, int> DoctorPatientVisitRepository)
        {
            this.DoctorPatientVisitRepository = DoctorPatientVisitRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = DoctorPatientVisitRepository.GetRecords();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = DoctorPatientVisitRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Doctor_Patient_Visit entity)
        {
            var response = DoctorPatientVisitRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Doctor_Patient_Visit entity)
        {
            var response = DoctorPatientVisitRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = DoctorPatientVisitRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}
