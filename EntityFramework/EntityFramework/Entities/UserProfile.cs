namespace EntityFrameworkCore_DotNet.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }

        // Foreign Key: الرابط مع User
        public int UserId { get; set; }

        // Navigation property: كل Profile مرتبط بـ User واحد
        public User User { get; set; }
    }
}
