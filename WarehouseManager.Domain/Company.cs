using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Domain
{
    public class Company : IEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public OwnerUser Owner { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }


        public ICollection<EmployeeUser> Employees { get; set; }
    }
}
