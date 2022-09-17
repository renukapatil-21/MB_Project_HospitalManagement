using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBHospital.Controllers
{

    [ApiController]
    [Route("patient_medicine")]
    public class PatientMedicineController : ControllerBase
    {
        private readonly IServiceRepository<Patient_Medicine, int> patientmedicineRepository;

        public PatientMedicineController(IServiceRepository<Patient_Medicine, int> patientmedicineRepository)
        {
            this.patientmedicineRepository = patientmedicineRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = patientmedicineRepository.GetRecords();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = patientmedicineRepository.GetRecord(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Patient_Medicine entity)
        {
            var response = patientmedicineRepository.CreateRecord(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient_Medicine entity)
        {
            var response = patientmedicineRepository.UpdateRecord(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = patientmedicineRepository.DeleteRecord(id);
            return Ok(response);
        }
    }
}