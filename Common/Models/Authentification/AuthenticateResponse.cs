using Todo.Common.Mapping;
using Todo.Persistence.Entities;
using AutoMapper;

namespace Todo.Common.Models.Authentification
{
    public class AuthenticateResponse : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Img { get; set; }
        public string Token { get; set; }
        public string todo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthenticateResponse, User>().ReverseMap();
        }
    }
}