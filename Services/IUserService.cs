using System.Threading.Tasks;
using PetstoreApi.Dtos;
using PetstoreApi.Models;

namespace PetstoreApi.Services
{
    public interface IUserService
    {
        Task<ResponseDto> SaveUser(User user);
        Task<ResponseDto> LoadUser(string biin);
        Task<ResponseDto> UpdateUser(string biin, string phone);
    }
}