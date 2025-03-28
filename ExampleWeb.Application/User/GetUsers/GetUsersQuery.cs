using MediatR;


namespace ExampleWeb.Application.User.GetUsers
{
    /// <summary>
    /// Запрос на получение данных по пользователю
    /// </summary>
    public class GetUsersQuery : IRequest<GetUsersResponse>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int[] Ids { get; set; } = default!;
    }
}
