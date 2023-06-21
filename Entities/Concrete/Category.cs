using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Core.Entities;

namespace Entities.Concrete
{
    //Çıplak class kalmasın.

	public class Category : IEntity
	{
        //[Key, Column("category_id")]
        public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }
	}
}

