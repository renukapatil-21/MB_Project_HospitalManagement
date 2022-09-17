﻿namespace MBHospital.Repositories
{
    public class DoctorRepository : IServiceRepository<Doctor, int>
    {
        IDataAccess<Doctor, int> dataAccess;

        public DoctorRepository(IDataAccess<Doctor, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Doctor> CreateRecord(Doctor entity)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
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

        public ResponseStatus<Doctor> DeleteRecord(int id)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
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

        public ResponseStatus<Doctor> GetRecord(int id)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
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

        public ResponseStatus<Doctor> GetRecords()
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
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

        public ResponseStatus<Doctor> UpdateRecord(int id, Doctor entity)
        {
            ResponseStatus<Doctor> response = new ResponseStatus<Doctor>();
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
