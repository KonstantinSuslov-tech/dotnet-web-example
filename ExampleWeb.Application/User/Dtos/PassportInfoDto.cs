using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWeb.Application.User.Dtos
{
    /// <summary>
    /// Паспорт
    /// </summary>
    public class PassportInfoDto
    {
        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public int Series { get; set; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTimeOffset IssueDate { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTimeOffset Birthday { get; set; }

    }
}
