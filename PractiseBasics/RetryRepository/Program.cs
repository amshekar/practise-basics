using System;

namespace RetryRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbContext<Policy> dbContext = new DbContext<Policy>();
            IRepository<Policy> repository = new Repository<Policy>(dbContext);
            IRetryOnFailure retryOnFailure = new RetryOnFailure();
            PolicyRepository policyRepository = new PolicyRepository(repository, retryOnFailure);
            Policy policy = new Policy {Id=1,Source="Epam" ,Destination="employee",Money=5500};
            policyRepository.Save(policy);
            Console.WriteLine("Hello World!");
        }
    }
}
