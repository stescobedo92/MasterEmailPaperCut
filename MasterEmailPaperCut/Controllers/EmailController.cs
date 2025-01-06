using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterEmailPaperCut.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController(IFluentEmail _emailService) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(SendEmail email)
    {
        SendResponse response = await _emailService
            .To(email.ToEmail)
            .Subject(email.Subject)
            .Body(email.Message)
            .SendAsync();
        
        return response.Successful ? Ok(response) : BadRequest(response);
    }
}

public record SendEmail(string ToEmail, string Subject, string Message);