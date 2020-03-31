namespace signalr_hub.DataStorage
{
    using signalr_hub.Models;
    using System.Collections.Generic;

    public class Users
    {
        public static List<User> GetUser()
        {
            return new List<User>()
            {
                new User { Id = 1, Nickname = "CSA User 1", ChatGroup = 1, Department = "CSA" },
                new User { Id = 2, Nickname = "CSA User 2", ChatGroup = 1, Department = "CSA" },
                new User { Id = 3, Nickname = "CSD User 1", ChatGroup = 2, Department = "CSD" },
                new User { Id = 4, Nickname = "RM User 1", ChatGroup = 3, Department = "RM" },
                new User { Id = 5, Nickname = "Settlement User 1", ChatGroup = 4, Department = "Settlement" },
            };
        }
    }
}
