using signalr_hub.Models;
using System.Collections.Generic;

namespace signalr_hub.DataStorage
{
    public class Users
    {
        public static List<User> GetUser()
        {
            return new List<User>()
            {
                new User { UserName = "User1", UserGroup = "MYR" },
                new User { UserName = "User2", UserGroup = "MYR" },
                new User { UserName = "User3", UserGroup = "CNY" },
                new User { UserName = "User4", UserGroup = "CNY" },
                new User { UserName = "User5", UserGroup = "INR" },
            };
        }
    }
}
