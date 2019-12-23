using System;
using System.ComponentModel.DataAnnotations;
using WarehouseManager.Domain.Enums;
using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Domain
{
    public class SupplyEntry : IEntity
    {
        [Required]
        public EntryType Type { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        public int SupplyId { get; set; }

        public Supply Supply { get; set; }
    }
}
