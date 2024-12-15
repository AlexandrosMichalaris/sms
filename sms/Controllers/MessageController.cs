namespace sms;
using Microsoft.AspNetCore.Mvc;
using sms.Models.Domain;
using sms.Services.Strategy;

[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly ISMSVendorStrategy _factory;

    public MessageController(ISMSVendorStrategy factory)
    {
        _factory = factory;
    }

    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> Send([FromBody] MessageRequest request)
    {
        try
        {
            if(!Enum.IsDefined(typeof(Vendor), request.Vendor))
                return BadRequest(new ApiResponse($"{typeof(MessageController)} Such Vendor doesn't exist", false));

            var service = _factory.GetVendor((Vendor)request.Vendor);

            await service.Send(request);

            return Ok(new ApiResponse<string>($"Message was sent successfully. | Message: {request.Message}"));

        } catch(Exception ex) 
        {
            return BadRequest(new ApiResponse(ex.Message, false));
        }
    }
}
