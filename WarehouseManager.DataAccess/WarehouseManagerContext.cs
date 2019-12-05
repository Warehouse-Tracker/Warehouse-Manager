using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WarehouseManager.Domain;

namespace WarehouseManager.DataAccess
{
    public class WarehouseManagerContext : ApiAuthorizationDbContext<User>
    {
        public WarehouseManagerContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
    }
}
