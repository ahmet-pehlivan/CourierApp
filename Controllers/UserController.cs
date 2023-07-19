﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using trendyolGO.Models;
using trendyolGO.Services;

namespace trendyolGO.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController 
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("all")]
        public async Task<BaseResponse<List<UserResponse>>> GetAll([FromQuery] int role)
        {

            try
            {
                var response = new BaseResponse<List<UserResponse>>(
                    payload: null,
                    statusCode: HttpStatusCode.OK,
                    friendlyMessage: null
                );


                var result = await _userService.GetAllUsersByRole(role);
                if (result.Count > 0)
                {
                    var friendlyMessage = new FriendlyMessage
                    { Title = "Success", Message = "All data fetched successfuly." };
                    response.Payload = result;
                    response.FriendlyMessage = friendlyMessage;
                }
                else
                {
                    var friendlyMessage = new FriendlyMessage { Title = "Not Found", Message = "Not Found" };
                    response.FriendlyMessage = friendlyMessage;
                    response.StatusCode = HttpStatusCode.NotFound;
                }

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BaseResponse<List<UserResponse>>(payload: null,
                    statusCode: HttpStatusCode.InternalServerError,
                    friendlyMessage: new FriendlyMessage { Title = "Error", Message = "Error" });
            }

        }

    }