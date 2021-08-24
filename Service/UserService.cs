using MVC_CRUD.DAL;
using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Service
{
    public class UserService
    {
        UserDal uda = new UserDal();

     public int  insertuserservice(User user)
        {
            return uda.insertuserservice(user);
        }


        public List<User> getAllUserList()
        {
            return uda.getAllUserList();
        }
        public List<User> getUserByID(string edit)
        {
            return uda.getUserByID(edit);
        }

        
        public int updateuserservice(User user)
        {
            return uda.UpdateUser(user);
        }
        public int SoftDelete(string id)
        {
            return uda.SoftDelete(id);
        }
    }
 
}