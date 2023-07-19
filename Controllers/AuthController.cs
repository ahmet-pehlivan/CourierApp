using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using trendyolGO.Models;
using trendyolGO.Services;

namespace trendyolGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IAuthService _authService;

        public AuthController(IJwtHandler jwtHandler, IAuthService authService)
        {
            _jwtHandler = jwtHandler;
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<BaseResponse<JwtTokenResource>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = new BaseResponse<JwtTokenResource>(
                    payload: null,
                    statusCode: HttpStatusCode.OK,
                    friendlyMessage: null
                    );
                var user = await _authService.Authenticate(request);
                if (user == null)
                {
                    var friendlyMessage = new FriendlyMessage { Title = "Not Found", Message = "User not Found" };
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.FriendlyMessage = friendlyMessage;
                }
                else if (user.Password != request.Password)
                {
                    var friendlyMessage = new FriendlyMessage { Title = "Wrong", Message = "UserName or Password is wrong" };
                    response.StatusCode = HttpStatusCode.Forbidden;
                    response.FriendlyMessage = friendlyMessage;
                }
                else
                {
                    var friendlyMessage = new FriendlyMessage { Title = "Success", Message = "You Loggin Succesfuly." };
                    response.Payload = _jwtHandler.CreateAccessToken(user.Username, user.Password, user.Role);
                    response.FriendlyMessage = friendlyMessage;
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new BaseResponse<JwtTokenResource>(payload: null,
                    statusCode: HttpStatusCode.InternalServerError,
                    friendlyMessage: new FriendlyMessage { Title = "Error", Message = "Error" });
            }
        }
    }
}
