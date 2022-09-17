using System;
namespace MBHospital.Repositories
{
    public class WardboyRepository : IServiceRepository<Wardboy, int>
    {
        IDataAccess<Wardboy, int> dataAccess;

        public WardboyRepository(IDataAccess<Wardboy, int> dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ResponseStatus<Wardboy> CreateRecord(Wardboy entity)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
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

        public ResponseStatus<Wardboy> DeleteRecord(int id)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
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

        public ResponseStatus<Wardboy> GetRecord(int id)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
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

        public ResponseStatus<Wardboy> GetRecords()
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
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

        public ResponseStatus<Wardboy> UpdateRecord(int id, Wardboy entity)
        {
            ResponseStatus<Wardboy> response = new ResponseStatus<Wardboy>();
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

