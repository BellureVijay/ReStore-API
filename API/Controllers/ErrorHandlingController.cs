using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace API.Controllers
{
    public class ErrorHandlingController:BaseApiController
    {
        [HttpGet("not-found")]

        public ActionResult GetNotFound()
        {
            return NotFound();
        }
        [HttpGet("bad-request")]

        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title="This is a Bad Request"});
        }
        
        [HttpGet("validation-error")]

        public ActionResult GetVaidationError()
        {
            ModelState.AddModelError("Problem1", "This is the first Erorr");
            ModelState.AddModelError("Problem2", "This is the second Erorr");
            return ValidationProblem();
        }

        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorisedError()
        {
            return Unauthorized();
        }
        
        [HttpGet("server-error")]

        public ActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }
    }
}
