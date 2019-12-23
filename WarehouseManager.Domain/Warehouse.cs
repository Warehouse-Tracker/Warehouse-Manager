using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Domain
{
    public class Warehouse : IEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 5)]
        public string Address { get; set; }

        /// <summary>
        /// The capacity of the warehouse in metric tons.
        /// </summary>
        [Required]
        [Range(1, double.MaxValue)]
        public double Capacity { get; set; }

        public ICollection<Supply> Supplies { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
