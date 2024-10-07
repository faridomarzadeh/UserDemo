using System.Collections.Generic;
using UserDemo.Models;
using UserDemo.Models.DTO;

namespace UserDemo.Services
{
    public interface IUserService
    {
        int GetUserCount();
        List<UserReportDto> GetUserReports(int page = 1, int numberofrows = 5);
        User Login(string email, string password);
        bool RegisterUser(User user);
        bool RegisterManager(User user);
        bool RegisterAdmin(User user);
    }
}