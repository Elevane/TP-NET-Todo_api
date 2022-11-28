using Todo.Common.Mapping;
using Todo.Persistence.Entities;
using AutoMapper;

namespace Todo.Common.Models.Authentification
{
    public class CreateUserRequest : IMapFrom<User>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserRequest, User>().ReverseMap();
        }
    }
}