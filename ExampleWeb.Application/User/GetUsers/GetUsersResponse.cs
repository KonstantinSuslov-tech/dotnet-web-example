using ExampleWeb.Application.User.Dtos;

namespace ExampleWeb.Application.User.GetUsers
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    public class GetUsersResponse
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDto[] Users { get; set; } = default!;
    }
}
