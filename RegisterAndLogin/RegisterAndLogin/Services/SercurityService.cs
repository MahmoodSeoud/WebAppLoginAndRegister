using RegisterAndLogin.Models;

namespace RegisterAndLogin.Services
{
    public class SercurityService
    {
        UsersDAO usersDAO = new UsersDAO();

        public bool isValid(UserModel user)
        {
            return usersDAO.FindUserByNameOrPassword(user);
        }
    }
}
