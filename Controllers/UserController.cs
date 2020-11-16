using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetstoreApi.Dtos;
using PetstoreApi.Models;
using PetstoreApi.Services;

namespace PetstoreApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            return Ok(await _userService.SaveUser(user));
        }
        [HttpGet("{biin}")]
        public async Task<IActionResult> GetBiin(string biin)
        {
            return Ok(await _userService.LoadUser(biin));
        }
        [HttpPost("updatePhone")]
        public async Task<IActionResult> UpdatePhone([FromBody] UserPhoneDto userPhoneDto)
        {
            return Ok(await _userService.UpdateUser(userPhoneDto.Biin, userPhoneDto.Phone));
        }
    }
}