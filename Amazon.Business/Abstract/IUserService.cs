using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.Business.Abstract
{
    public interface IUserService
    {
         User GetUser(string username, string password);
        User GetUserByUserName(string username);
      
        void Add(string UserName,string Password,string email,string Name);
        void Update(User user);
    }
}
