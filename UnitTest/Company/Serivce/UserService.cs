using Company.Model;

namespace Company.Serivce
{
    public class UserService
    {
        public bool Register(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
                throw new Exception("Email is required");

            if (!user.Email.Contains("@"))
                return false;

            if (user.Password.Length < 6)
                return false;

            if (!user.Password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
        public bool Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Email is required");

            if (password.Length < 6)
                return false;

            if (password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
