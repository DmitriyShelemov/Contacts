using ContactsApi.Database;
using ContactsApi.Logic.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ContactsApi.Logic
{
    public class UserService : IUserService
    {
        private const string PwdSalt = "Qz0WrhYxbqInFQ7DQKF+cA==";
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> FindAsync(string email, string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var hash = CalcHash(password);
            return hash == user.Password ? user : null;
        }

        private string CalcHash(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Convert.FromBase64String(PwdSalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}