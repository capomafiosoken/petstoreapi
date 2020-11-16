using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetstoreApi.Dtos;
using PetstoreApi.Models;

namespace PetstoreApi.Services
{
    public class PetstoreService
    {
        private readonly HttpClient _httpClient;

        public PetstoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PetstoreResponseDto> SaveUser(User userDto)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"), "https://petstore.swagger.io/v2/user")
            {
                Content = new StringContent(
                    $"{{ \"id\": {userDto.UserId}, \"username\": \"{userDto.Biin}\", \"firstname\": \"{userDto.Firstname}\", \"lastname\": \"{userDto.Lastname}\", \"email\": \"{userDto.Email}\", \"password\": \"{userDto.Password}\", \"phone\": \"{userDto.Phone}\" }}")
            };
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

            var response = await _httpClient.SendAsync(request);
            var content = JsonConvert.DeserializeObject<PetstoreResponseDto>(await response.Content.ReadAsStringAsync());
            return content;
        }
        public async Task<PetstoreUserResponseDto> LoadUser(string username)
        {
            var response = await _httpClient.GetAsync($"https://petstore.swagger.io/v2/user/{username}");
            return JsonConvert.DeserializeObject<PetstoreUserResponseDto>(await response.Content.ReadAsStringAsync());
        }
        public async Task<PetstoreResponseDto> UpdatePhone(long id, string phone)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"), "https://petstore.swagger.io/v2/user")
            {
                Content = new StringContent(
                    $"{{ \"id\": {id}, \"phone\": \"{phone}\" }}")
            };
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

            var response = await _httpClient.SendAsync(request);
            var content = JsonConvert.DeserializeObject<PetstoreResponseDto>(await response.Content.ReadAsStringAsync());
            return content;
        }
    }
}