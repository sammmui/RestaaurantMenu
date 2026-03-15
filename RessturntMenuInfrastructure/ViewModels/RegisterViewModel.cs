using System.ComponentModel.DataAnnotations;

namespace RestaurantMenuInfrastructure.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Вкажіть Email")]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Вкажіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string ConfirmPassword { get; set; } = default!;

        [Required(ErrorMessage = "Вкажіть рік народження")]
        [Range(1920, 2026, ErrorMessage = "Некоректний рік")]
        public int Year { get; set; }
    }
}