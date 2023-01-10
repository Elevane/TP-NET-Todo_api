using AutoMapper;
using Todo.Common.Mapping;
using Todo.Persistence.Entitites;

namespace Todo.Common.Models
{
    public class ProjectDto : IMapFrom<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Tag { get; set; }

        public string Childs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}