using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    /// <summary>
    /// Controleur d'API - expose les méthodes sous forme HTTP
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        protected ActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected ActionResult BadRequest(string errorMessage)
        {
            return base.BadRequest(Envelope.Error(errorMessage));
        }

        protected ActionResult NotFound(string errorMessage)
        {
            return base.NotFound(Envelope.Error(errorMessage));
        }
    }
}