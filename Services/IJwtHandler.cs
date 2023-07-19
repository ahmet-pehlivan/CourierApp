﻿using trendyolGO.Models;

namespace trendyolGO.Services
{
    public interface IJwtHandler
    {
        public JwtTokenResource CreateAccessToken(string userId, string username, int role);
        public JwtTokenResource CreateRefreshToken(string userId, string username);
    }
}
