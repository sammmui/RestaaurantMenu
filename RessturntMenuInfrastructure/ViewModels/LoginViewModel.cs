using System.ComponentModel.DataAnnotations;

namespace RestaurantMenuInfrastructure.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введіть Email")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}