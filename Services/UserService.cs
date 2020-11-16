using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetstoreApi.Dtos;
using PetstoreApi.Models;

namespace PetstoreApi.Services
{
    public class UserService : IUserService
    {
        private readonly PetstoreService _petstoreApi;
        private readonly UserContext _userContext;

        public UserService(PetstoreService petstoreApi, UserContext userContext)
        {
            _petstoreApi = petstoreApi;
            _userContext = userContext;
        }

        public async Task<ResponseDto> SaveUser(User user)
        {
            var petstoreResponse = await _petstoreApi.SaveUser(user);
            if (petstoreResponse.Code != 200)
            {
                return new ErrorResponseDto
                {
                    Success = false,
                    Message = petstoreResponse.Message
                };
            }
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
            return new ResponseDto
            {
                Success = true
            };
        }

        public async Task<ResponseDto> LoadUser(string biin)
        {
            var petstoreResponse = await _petstoreApi.LoadUser(biin);
            if (petstoreResponse.Code != null && petstoreResponse.Code != 200)
            {
                return new ErrorResponseDto
                {
                    Success = false,
                    Message = petstoreResponse.Message
                };
            }

            return new DataResponseDto
            {
                Success = true,
                Data = new DataResponseDto.UserData
                {
                    UserId = petstoreResponse.Id,
                    Email = petstoreResponse.Email,
                    Phone = petstoreResponse.Phone,
                    Password = petstoreResponse.Password
                }
            };
        }

        public async Task<ResponseDto> UpdateUser(string biin, string phone)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x => x.Biin == biin);
            if (user == null)
            {
                return new ErrorResponseDto
                {
                    Success = false,
                    Message = "User does not exists"
                };
            }

            var petstoreResponse = await _petstoreApi.UpdatePhone(user.UserId, phone);
            if (petstoreResponse.Code != 200)
            {
                return new ErrorResponseDto
                {
                    Success = false,
                    Message = petstoreResponse.Message
                };
            }

            return new ResponseDto
            {
                Success = true
            };
        }
    }
}