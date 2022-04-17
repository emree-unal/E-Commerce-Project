using Amazon.Business.Abstract;
using Amazon.DataAccess.Abstract;
using Amazon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amazon.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }

        public void Add(string UserName, string Password, string email, string Name)
        {
            User newuser = new User();
            newuser.UserName = UserName;
            newuser.Email = email;
            newuser.Password = Password;
            newuser.Name = Name;
            newuser.Role = "User";
            _userDal.Add(newuser);
           
        }

        public User GetUser(string username, string password=null)
        {
            
          return _userDal.Get(x => x.UserName == username && x.Password == password);
            
        }

        public User GetUserByUserName(string username)
        {
            return _userDal.Get(x => x.UserName == username);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
        //public List<User> GetUsers()
        //{
        //    return _userDal.GetAllEntities();
        //}

        //public User UserIsValid(string username, string password)
        //{
        //    List<User> users = GetUsers();
        //    return users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        //}
    }
}
