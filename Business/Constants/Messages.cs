using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string BrandsListed = "Modeller listelendi";
        public static string BrandAdded = "Model eklendi";
        public static string BrandNameValid = "Araba ismi en az 2 karakter olmalıdır.";
        public static string CarPriceInvalid = "Araba fiyatı geçersiz fiyat 0'dan büyük olmalıdır.";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string RentalAdded = "Kiralama oluşturuldu";
        public static string RentalInvalid = "Araba teslim edilmediği için kiralanamaz";
        public static string ColorAdded ="Renk eklendi.";
        public static string CarImageAdded ="Araba resmi eklendi";
        public static string CarImageLimitExceded ="Bir arabanın en fazla 5 resmi olabilir";
        public static string CarImageDeleted ="Araba resmi silindi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = " Token oluşturuldu";
    }
}
