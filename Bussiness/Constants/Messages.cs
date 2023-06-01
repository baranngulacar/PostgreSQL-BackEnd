using System;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Bussiness.Constants
{
	public static class Messages
	{
		public static string ProductAdded = "Ürün Eklendi!";

		public static string ProductNameInvalid = "Ürün İsmi Geçersiz!";

		public static string MaintenanceTime = "Sistem bakımda";

		public static string ProductsListed = "Ürünler listelendi";

		public static string ProductCountOfCategoryError = "Max 15 olabilir!";

		public static string ProductNameAlreadyExsists = "Bu isimde zaten bir ürün var!";

		public static string CategoryLimitExceded = "Kateori limitini aştınız!";

		public static string AuthorizationDenied = "Yetkiniz yok!";

		public static string UserRegistered = "Kayıt oldunuz!";

		public static string UserNotFound = "Kullanıcı bulunamadı!";

		public static string PasswordError = "Parola hatası!";

		public static string SuccessfulLogin = "Başarılı giriş! ";

		public static string UserAlreadyExists = "Kullanıcı mevcut!";

		public static string AccessTokenCreated { get; internal set; }
    }
}
