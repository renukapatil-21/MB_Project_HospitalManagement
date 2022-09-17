using System;

namespace MBHospital.Repositories
{
    public class PatientRoomRepository : IServiceRepository<Patient_Room, int>
    {
        IDataAccess<Patient_Room, int> dataAccess;

        public PatientRoomRepository(IDataAccess<Patient_Room, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Patient_Room> CreateRecord(Patient_Room entity)
        {
            ResponseStatus<Patient_Room> response = new ResponseStatus<Patient_Room>();
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

        public ResponseStatus<Patient_Room> DeleteRecord(int id)
        {
            ResponseStatus<Patient_Room> response = new ResponseStatus<Patient_Room>();
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

        public ResponseStatus<Patient_Room> GetRecord(int id)
        {
            ResponseStatus<Patient_Room> response = new ResponseStatus<Patient_Room>();
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

        public ResponseStatus<Patient_Room> GetRecords()
        {
            ResponseStatus<Patient_Room> response = new ResponseStatus<Patient_Room>();
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

        public ResponseStatus<Patient_Room> UpdateRecord(int id, Patient_Room entity)
        {
            ResponseStatus<Patient_Room> response = new ResponseStatus<Patient_Room>();
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

