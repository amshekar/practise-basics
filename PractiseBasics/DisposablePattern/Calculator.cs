using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DisposablePattern
{
    public class Calculator :IDisposable
    {
        public decimal ToatalPrice(decimal price,int taxPercentage)
        {
            return price + (price * taxPercentage);
        }

        #region IDisposable Support
        private IntPtr _buffer; // unmanaged resource
        private SafeHandle _resource; // managed resource
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    if (_resource!=null)
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
        ~Calculator()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
