using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Common.Helpers;
using Todo.Common.Models;
using Todo.Common.Models.Authentification;
using Todo.Persistence;
using Todo.Persistence.Entities;
using Todo.Persistence.Entitites;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoController : BaseApiController
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;
        private readonly int userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TodoController(TodoContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            var user = _httpContextAccessor.HttpContext.Items["User"];
            if (user == null)
                throw new Exception("No user is authenticated");

            userId = int.Parse(user.GetType().GetProperty("Id").GetValue(user, null).ToString());
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] string json)
        {
            User entity = await _context.Users.Where(user => user.Id == userId).FirstOrDefaultAsync();
            entity.todo = json;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
    }
}