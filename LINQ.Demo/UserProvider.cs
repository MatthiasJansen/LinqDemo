using System.Collections.Generic;

namespace LINQ.Demo
{
    public class UserProvider
    {
        public IEnumerable<User> Provide()
        {
            var json = System.IO.File.ReadAllText("users.json");

            return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(json);
        }
    }
}