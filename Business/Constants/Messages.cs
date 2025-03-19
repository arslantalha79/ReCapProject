using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi!";
        public static string InvalidBrandName = "Marka ismi en az 2 karakter olmalıdır!";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string SuccessfulCarListed = "Araçlar başarılı şekilde listelendi!";
        public static string BrandAdded = "Marka sisteme eklendi!";
        public static string BrandsListed = "Markalar başarılı bir şekilde listelendi!";
        public static string BrandExists = "Marka sistemde zaten kayıtlı!";
        public static string PlateTableAlreadyExists = "Araç plakası sisteme kayıtlı!";
        public static string CarsDetailsDtoListed = "Araç-Marka detayları listelendi!";
        
        
        //Customer Manager
        public static string CustomerAdded = "Müşteri sisteme eklendi!";
        public static string CustomerDeleted = "Müşteri sistemden silindi!";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi!";
        public static string NationalIdentityRegistered = "TC kimlik sisteme kayıtlı!";
        
        //Auth Manager
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi!";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Şifre hatalı!";
        public static string SuccessfulLogin = "Kullanıcı başarıyla giriş yaptı!";
        public static string? AuthorizationDenied = "Yetkiniz yok!";
    }
}
