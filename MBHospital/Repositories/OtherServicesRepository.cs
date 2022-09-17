namespace MBHospital.Repositories
{

   public class OtherServicesRepository : IServiceRepository<Other_Services, int>
    {
        IDataAccess<Other_Services, int> dataAccess;

        public OtherServicesRepository(IDataAccess<Other_Services, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Other_Services> CreateRecord(Other_Services entity)
        {
            ResponseStatus<Other_Services> response = new ResponseStatus<Other_Services>();
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

        public ResponseStatus<Other_Services> DeleteRecord(int id)
        {
            ResponseStatus<Other_Services> response = new ResponseStatus<Other_Services>();
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

        public ResponseStatus<Other_Services> GetRecord(int id)
        {
            ResponseStatus<Other_Services> response = new ResponseStatus<Other_Services>();
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

        public ResponseStatus<Other_Services> GetRecords()
        {
            ResponseStatus<Other_Services> response = new ResponseStatus<Other_Services>();
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

        public ResponseStatus<Other_Services> UpdateRecord(int id, Other_Services entity)
        {
            ResponseStatus<Other_Services> response = new ResponseStatus<Other_Services>();
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
