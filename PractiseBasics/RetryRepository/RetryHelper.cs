using System;
using System.Collections.Generic;
using System.Text;

namespace RetryRepository
{
    public static class RetryHelper
    {
        public static void ServiceCallRetry(Action method, int maxRetryCount = 3)
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
}
