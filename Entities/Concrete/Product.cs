using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Product : IEntity
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public short UnitsInStock { get; set; }

        public double UnitPrice { get; set; }

        public string? ProductName { get; set; }
    }
}

