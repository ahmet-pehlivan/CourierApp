using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using trendyolGO.Models;
using trendyolGO.Services;
using Microsoft.AspNetCore.Authorization;

namespace trendyolGO.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourierController : ControllerBase
{
    private readonly ICourierService _courierService;
    private readonly Context _context = null;

    public CourierController(ICourierService courierService)
    {
        _courierService = courierService;
    }

    //[HttpGet("all")]
    //public async Task<BaseResponse<List<CourierResponse>>> GetAll([FromQuery]int role)
    //{
    //    try
    //    {
    //        var response = new BaseResponse<List<CourierResponse>>(
    //            payload: null,
    //            statusCode: HttpStatusCode.OK,
    //            friendlyMessage: null
    //            );


    //        var result = await _courierService.GetAllCouriersByRole(role);
    //        if (result.Count > 0)
    //        {
    //            var friendlymessage = new FriendlyMessage
    //            {
    //                Title = "Success",
    //                Message = "All Data Fetched Succesfully."
    //            };
    //            response.Payload = result;
    //            response.FriendlyMessage = friendlymessage;
    //        }
    //        else
    //        {
    //            var friendlyMessage = new FriendlyMessage { Title = "Not Found", Message = "Not Found" };
    //            response.FriendlyMessage = friendlyMessage;
    //            response.StatusCode = HttpStatusCode.NotFound;
    //        }
    //        return response;
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e);
    //        //return new BaseResponse<List<CourierResponse>>(payload: null,
    //        //    statusCode: HttpStatusCode.InternalServerError,
    //        //    friendlyMessage: new FriendlyMessage { Title = "Error", Message = "Error" });
    //    }
    //}
}



