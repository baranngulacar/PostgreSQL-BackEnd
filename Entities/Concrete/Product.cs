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

// bak simdi, veritabanı tablo isimleri buradakiler gibi olmalı. postgresql de tablo isimleri asdas_asdsad_asdasd gibi verilirken
// mssql de AasdAsdAsd gibi veriliyor. iki çeşit yöntem var biri gördüğün gibi uyumluluk ya tablo isimleri uyacak buraya
// ya da burası oraya uyacak gibi.

// ikinci yol ise EntityFramework içinde bir configuration fonk. var orada elle belirtiyoruz. Bizdeki ProductId ala => tablodaki product_id
// alanına denk geliyor diye programa bilgi veriyoruz o da bize göre uyarlıyor. Anlatabildim mi? //sağol abi :))

// görüşürüz
