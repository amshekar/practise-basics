using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace RetryRepository
{


    #region RetryPolicyRepository


    public class PolicyRepository : Repository<Policy>
    {
        private IRepository<Policy> _repository;
        private IRetryOnFailure _retryOnFailure;
        public PolicyRepository(IRepository<Policy> repository,IRetryOnFailure retryOnFailure)
        {
            _repository = repository;
            _retryOnFailure = retryOnFailure;
        }

        public void Save(Policy policyEntity)
        {
            //RetryHelper.ServiceCallRetry(() => _repository.Save(policyEntity));
            _retryOnFailure.RetryOnConnectionFailure(()=>_repository.Save(policyEntity));

        }
    }

    public interface IRetryOnFailure
    {
        void RetryOnConnectionFailure(Action method, int maxRetryCount = 3);
    }
    public class RetryOnFailure : IRetryOnFailure
    {
        public void RetryOnConnectionFailure(Action method, int maxRetryCount = 3)
        {
            var retryCount = 0;
            while (retryCount < maxRetryCount)
            {
                try
                {
                    method();
                    return;
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToString() == "expected")
                    {
                        retryCount++;
                    }
                    else

                        throw;
                }
                //catch (Exception ex)
                //{
                //    retryCount = 3;
                //     throw;

                //}

            }
            throw new Exception("Please contact custome care some issue with database connection");
        }
    }

    
    public class Policy
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal Money { get; set; }

    }
    #endregion

    #region GenericRepository    

    public interface IRepository<T> where T : class
    {
        void Save(T Entity);
    }
    public class Repository<T> : IRepository<T>,IDisposable where T : class
    {
        private IDbContext<T> _dbContext;
        public Repository()
        {
            _dbContext = new DbContext<T>();
        }
        public Repository(IDbContext<T> dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save(T entity)
        {
            _dbContext.save(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private SafeHandle _resource;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    // dispose managed state (managed objects).
                    if (_resource != null)
                    {
                        _resource.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Repository()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    #endregion

    #region DataAccessRepository


    public interface IDbContext<T> where T : class
    {
        void save(T Entity);

    }
    public class DbContext<T> : IDbContext<T> where T : class
    {
        public void save(T Entity)
        {
            throw new Exception("expected");
        }
    }
    #endregion
}
