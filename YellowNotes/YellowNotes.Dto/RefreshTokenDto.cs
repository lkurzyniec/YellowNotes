using System;

namespace YellowNotes.Dto
{
    public class RefreshTokenDto
    {
        public string UserName { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime ExpiresDate { get; set; }

        public string ProtectedTicket { get; set; }

        public string Token { get; set; }
    }
}