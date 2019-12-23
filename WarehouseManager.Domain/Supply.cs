using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WarehouseManager.Domain.Enums;
using WarehouseManager.Domain.Interfaces;

namespace WarehouseManager.Domain
{
    public class Supply : IEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue)]
        public double CurrentAmount { get; set; }

        [Required]
        public Measurement Measure { get; set; }

        public ICollection<SupplyEntry> Entries { get; set; }
    }
}
