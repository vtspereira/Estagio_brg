using estagio_brg.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace estagio_brg.Repository
{
    public static class UserApiRepository
    {
        public static UserApi Get(string username, string password)
        {
            var users = new List<UserApi>();
            users.Add(new UserApi { Username = "estagioBrg", Password = "processoSeletivo" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }
    }
}
