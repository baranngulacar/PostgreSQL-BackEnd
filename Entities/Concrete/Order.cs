using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class Order : IEntity
	{
		public int OrderID { get; set; }

		public string CustomerID { get; set; }

		public int EmployeeID { get; set; }

		public DateTime OrderTime { get; set; }

		public string ShipCity { get; set; }
	}
}

