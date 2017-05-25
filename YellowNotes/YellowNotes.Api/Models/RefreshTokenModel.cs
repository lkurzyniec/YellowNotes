using System;

namespace YellowNotes.Api.Models
{
    internal class RefreshTokenModel
    {
        public string UserName { get; set; }

        public string ClientId { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime ExpiresDate { get; set; }

        public string ProtectedTicket { get; set; }

        public string Token { get; set; }
    }
}