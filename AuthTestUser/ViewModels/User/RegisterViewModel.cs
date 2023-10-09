using System.ComponentModel.DataAnnotations;

namespace AuthTestUser.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "فیلد کد کاربری اجباری است.")]
        [MaxLength(200, ErrorMessage = "حداکثر طول کد کاربری 200 کاراکتر می‌باشد.")]
        public string User_Code { get; set; }

        [Required(ErrorMessage = "فیلد رمز عبور اجباری است.")]
        [MaxLength(200, ErrorMessage = "حداکثر طول رمز عبور 200 کاراکتر می‌باشد.")]
        public string User_Pass { get; set; }

        [Required(ErrorMessage = "فیلد نام کامل اجباری است.")]
        [MaxLength(300, ErrorMessage = "حداکثر طول نام کامل 300 کاراکتر می‌باشد.")]
        public string User_FullName { get; set; }
    }
}
