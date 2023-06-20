using System.Security.Cryptography;

namespace BlazorEcommerce.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _ctx;

        public AuthService(DataContext context)
        {
            _ctx = context;
        }
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] salt);

            user.PasswordHash = passwordHash;
            user.PasswrodSalt = salt;

            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration succesfull." };
        }


        public async Task<bool> UserExists(string email)
        {
            if (await _ctx.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
