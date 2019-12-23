namespace WarehouseManager.Domain.Interfaces
{
    public interface IUser
    {
        int CompanyId { get; set; }

        Company Company { get; set; }

        string UserId { get; set; }

        User User { get; set; }
    }
}
