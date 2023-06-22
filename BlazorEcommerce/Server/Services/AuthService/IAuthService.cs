﻿namespace BlazorEcommerce.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> UserExists(String email);
        Task<ServiceResponse<string>> Login(string email, string password);
    }
}
