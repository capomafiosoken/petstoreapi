namespace PetstoreApi.Dtos
{
    public class ResponseDto
    {
        public bool Success { get; set; }
    }

    public class DataResponseDto : ResponseDto
    {
        public UserData Data { get; set; }

        public class UserData
        {
            public long UserId { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }

    public class ErrorResponseDto : ResponseDto
    {
        public string Message { get; set; }
    }

    public class UserPhoneDto
    {
        public string Biin { get; set; }
        public string Phone { get; set; }
    }
}