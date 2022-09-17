namespace MBHospital.Repositories
{

    public class HospitalSettingRepository : IServiceRepository<Hospital_Setting, int>
    {
        IDataAccess<Hospital_Setting, int> dataAccess;

        public HospitalSettingRepository(IDataAccess<Hospital_Setting, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Hospital_Setting> CreateRecord(Hospital_Setting entity)
        {
            ResponseStatus<Hospital_Setting> response = new ResponseStatus<Hospital_Setting>();
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

        public ResponseStatus<Hospital_Setting> DeleteRecord(int id)
        {
            ResponseStatus<Hospital_Setting> response = new ResponseStatus<Hospital_Setting>();
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

        public ResponseStatus<Hospital_Setting> GetRecord(int id)
        {
            ResponseStatus<Hospital_Setting> response = new ResponseStatus<Hospital_Setting>();
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

        public ResponseStatus<Hospital_Setting> GetRecords()
        {
            ResponseStatus<Hospital_Setting> response = new ResponseStatus<Hospital_Setting>();
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

        public ResponseStatus<Hospital_Setting> UpdateRecord(int id, Hospital_Setting entity)
        {
            ResponseStatus<Hospital_Setting> response = new ResponseStatus<Hospital_Setting>();
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
