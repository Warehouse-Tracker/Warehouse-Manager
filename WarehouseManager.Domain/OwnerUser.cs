using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Domain
{
    public class OwnerUser : IUser, IEntity
    {
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
