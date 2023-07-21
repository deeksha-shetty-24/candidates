using Aykan.SRM.Common.Helpers;
using Candidate.Business.Contracts;
using Candidate.Model;
using Candidate.Repository.Contracts;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;

namespace Candidate.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _memoryCache = memoryCache;
        }

        public async Task<AuthenticationModel> GetUserDetails(LoginModel loginModel)
        {
            var user = (await _userRepository.GetByAsync(x => x.UserName == loginModel.UserName)).FirstOrDefault();
            if (user == null)
            {
                return new AuthenticationModel() { Error = "Please make sure username and password are correct and try again!" };
            }
            if (user.Password == Cryptography.ComputeSHA256Hash(loginModel.Password, user.CreatedOn.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)))
            {
                var token = Cryptography.GetRandomString(32);
                var cacheExpiryOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddHours(1),
                    SlidingExpiration = TimeSpan.FromMinutes(30),
                    Priority = CacheItemPriority.Normal
                };
                _memoryCache.Set(user.Id, token, cacheExpiryOptions);
                var value = _memoryCache.Get(user.Id);
                return new AuthenticationModel() { Name = user.Name, Token = token, UserId = user.Id };
            }
            return new AuthenticationModel() { Error = "Password is incorrect. Please try again!" };
        }
    }
}