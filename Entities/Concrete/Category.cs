using System;
using Core.Entities;

namespace Entities.Concrete
{
	//Çıplak class kalmasın.

	public class Category : IEntity
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }
	}
}

