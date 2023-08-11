namespace Dentistry.Common.Constant;

public static class Statement
{
      public const string SuccessMessage = "عملیات با موفقیت انجام شد";
      public const string NotFoundMessage = "موردی یافت نشد";
      public const string UnauthorizedMessage = "احراز هویت کاربر با مشکل مواجه شد";
      public const string FailureMessage = "در اجرای عملیات خطایی رخ داده است";
      public const string ForbiddenMessage = "به این سرویس دسترسی ندارید";
      public const string DuplicateMessage = "اطلاعات وارد شده قبلا ثبت شده است";
      public const string Dependency = "به دلیل وابستگی اطلاعات امکان حذف وجود ندارد";
      public const string Duplicate = nameof(Duplicate);
      public const string NotFound = nameof(NotFound);
}
