using System;

namespace MBHospital.Repositories
{
    public class PatientMedicineRepository : IServiceRepository<Patient_Medicine, int>
    {
        IDataAccess<Patient_Medicine, int> dataAccess;


        public PatientMedicineRepository(IDataAccess<Patient_Medicine, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Patient_Medicine> CreateRecord(Patient_Medicine entity)
        {
            ResponseStatus<Patient_Medicine> response = new ResponseStatus<Patient_Medicine>();
            try
            {
                response.Record = dataAccess.Create(entity);
                response.Message = "Record is created successfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Patient_Medicine> DeleteRecord(int id)
        {
            ResponseStatus<Patient_Medicine> response = new ResponseStatus<Patient_Medicine>();
            try
            {
                response.Record = dataAccess.Delete(id);
                response.Message = "Record is delete successfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Patient_Medicine> GetRecord(int id)
        {
            ResponseStatus<Patient_Medicine> response = new ResponseStatus<Patient_Medicine>();
            try
            {
                response.Record = dataAccess.Get(id);
                response.Message = "Record is read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Patient_Medicine> GetRecords()
        {
            ResponseStatus<Patient_Medicine> response = new ResponseStatus<Patient_Medicine>();
            try
            {
                response.Records = dataAccess.Get();
                response.Message = "Records are read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Patient_Medicine> UpdateRecord(int id, Patient_Medicine entity)
        {
            ResponseStatus<Patient_Medicine> response = new ResponseStatus<Patient_Medicine>();
            try
            {
                response.Record = dataAccess.Update(id, entity);
                response.Message = "Record is updated successfully";
                response.StatusCode = 204;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}

