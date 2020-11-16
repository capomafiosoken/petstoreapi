namespace PetstoreApi.Dtos
{
    public class PetstoreResponseDto
    {
        public int? Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }

    public class PetstoreUserResponseDto : PetstoreResponseDto
    {
        public long Id { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public long UserStatus { get; set; }
    }
}