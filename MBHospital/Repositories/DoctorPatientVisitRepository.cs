namespace MBHospital.Repositories
{

    public class DoctorPatientVisitRepository : IServiceRepository<Doctor_Patient_Visit, int>
    {
        IDataAccess<Doctor_Patient_Visit, int> dataAccess;

        public DoctorPatientVisitRepository(IDataAccess<Doctor_Patient_Visit, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Doctor_Patient_Visit> CreateRecord(Doctor_Patient_Visit entity)
        {
            ResponseStatus<Doctor_Patient_Visit> response = new ResponseStatus<Doctor_Patient_Visit>();
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

        public ResponseStatus<Doctor_Patient_Visit> DeleteRecord(int id)
        {
            ResponseStatus<Doctor_Patient_Visit> response = new ResponseStatus<Doctor_Patient_Visit>();
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

        public ResponseStatus<Doctor_Patient_Visit> GetRecord(int id)
        {
            ResponseStatus<Doctor_Patient_Visit> response = new ResponseStatus<Doctor_Patient_Visit>();
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

        public ResponseStatus<Doctor_Patient_Visit> GetRecords()
        {
            ResponseStatus<Doctor_Patient_Visit> response = new ResponseStatus<Doctor_Patient_Visit>();
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

        public ResponseStatus<Doctor_Patient_Visit> UpdateRecord(int id, Doctor_Patient_Visit entity)
        {
            ResponseStatus<Doctor_Patient_Visit> response = new ResponseStatus<Doctor_Patient_Visit>();
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
