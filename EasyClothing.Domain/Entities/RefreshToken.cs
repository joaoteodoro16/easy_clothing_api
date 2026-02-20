using EasyClothing.Domain.Common;

namespace EasyClothing.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; private set; }

        public string Token { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public bool IsRevoked { get; private set; }

        public User User { get; private set; }

        private RefreshToken() { }

        public static RefreshToken Create(Guid userId, string token)
        {
            return new RefreshToken
            {
                UserId = userId,
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };
        }

        public void Revoke()
        {
            IsRevoked = true;
        }

        public bool IsExpired()
            => DateTime.UtcNow > ExpirationDate;
    }
}