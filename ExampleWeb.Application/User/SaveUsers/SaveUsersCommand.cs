using ExampleWeb.Application.User.Dtos;
using MediatR;

namespace ExampleWeb.Application.User.SaveUsers
{
    /// <summary>
    /// Команда сохранения пользователей
    /// </summary>
    public class SaveUsersCommand : IRequest<SaveUsersResponse>
    {
        /// <summary>
        /// Пользователи
        /// </summary>
        public UserDto[] Users { get; set; } = default!;
    }
}
