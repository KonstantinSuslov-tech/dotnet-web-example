using ExampleWeb.Application.User.Dtos;

namespace ExampleWeb.Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto UserMap(this Domain.Entities.User user) 
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PassportInfo = user.Passport?.ToPassportInfoDto(),
                Contacts = user.Contacts?.Select(c => c.ToContactDto()).ToArray()
            };            
        }


        public static PassportInfoDto ToPassportInfoDto(this Domain.Entities.Passport passportInfo)
        {
            return new PassportInfoDto
            {
                Number = passportInfo.Number,
                Series = passportInfo.Series,
                IssueDate = passportInfo.IssueDate,
                Birthday = passportInfo.Birthday
            };
        }


        public static ContactDto ToContactDto(this Domain.Entities.Contact contactDto)
        {
            return new ContactDto
            {
                Email = contactDto.Email,
                Phone = contactDto.Phone
            };
        }



        public static Domain.Entities.Contact ToContactDomain(this ContactDto contact) 
        {
            return new Domain.Entities.Contact(contact.Email,contact.Phone);
        }


        public static Domain.Entities.Passport ToPassportDomain(this PassportInfoDto passport)
        {
            return new Domain.Entities.Passport(passport.Number, passport.Series, passport.IssueDate, passport.Birthday);
        }


        public static Domain.Entities.User ToSaveUserDomain(this UserDto user) 
        {
            return new Domain.Entities.User(user.FirstName, user.LastName, user.Contacts.Select(c => c.ToContactDomain()).ToList(),
                user.PassportInfo.ToPassportDomain());    
        }
    }
}
