using Todo.Persistence.Entities;

namespace Todo.Persistence.Entitites
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Tag { get; set; }

        public string Childs { get; set; }
    }
}