using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/error")]
public class ErrorController : ControllerBase {
    public ActionResult error(){
        return StatusCode((int)HttpStatusCode.InternalServerError, "An internal error occured please try after sometime");
    }
}