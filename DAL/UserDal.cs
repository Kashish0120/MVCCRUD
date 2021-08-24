using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_CRUD.DAL
{
    public class UserDal
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public int insertuserservice(User user)
        {
            SqlConnection conn = null;
            string sql = "insert into users(fname,lname,email,phone,city,address) values('" + user.fname + "','" + user.lname + "','" + user.email + "','" + user.phone + "','" + user.city + "','"+user.address+"')";

            conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            int status = cmd.ExecuteNonQuery();

            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
           
        }
        public List<User> getAllUserList()
        {
           

            string sql = "select id,fname,lname,email,phone,city,address from users where active='Y'";

            List<User> userlist = new List<User>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using(SqlDataAdapter sda =  new SqlDataAdapter(cmd))
                    {
                        using(DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                User user = new User();
                                user.id = Convert.ToInt32(dr[0]);
                                user.fname = dr[1].ToString();
                                user.lname = dr[2].ToString();
                                user.email = dr[3].ToString();
                                user.phone = dr[4].ToString();
                                user.city = dr[5].ToString();
                                user.address = dr[6].ToString();

                                userlist.Add(user);
                            }
                        }
                    }
                    conn.Close();
                }
                
            }
            return userlist;
        }

        public List<User> getUserByID(string edit)
        {


            string sql = "select  id,fname,lname,email,phone,city,address from users where id='"+ edit + "'";

            List<User> editList = new List<User>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                User user = new User();
                                user.id = Convert.ToInt32(dr[0]);
                                user.fname = dr[1].ToString();
                                user.lname = dr[2].ToString();
                                user.email = dr[3].ToString();
                                user.phone = dr[4].ToString();
                                user.city = dr[5].ToString();
                                user.address = dr[6].ToString();

                                editList.Add(user);
                            }
                        }
                    }
                    conn.Close();
                }

            }
            return editList;
        }

        public int UpdateUser(User user)
        {

            SqlConnection conn = null;
            string sql = "update users set fname='"+ user.fname + "',lname='"+user.lname+"',email='"+user.email+"',phone='"+user.phone + "',city='"+user.city+"',address='"+user.address+"' where id='" + user.id + "'";
            conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            int status = cmd.ExecuteNonQuery();

            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }


        }

        public int SoftDelete(string  id)
        {

            SqlConnection conn = null;
            string sql = "update users set active ='N' where id='" + id + "'";
            conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            int status = cmd.ExecuteNonQuery();

            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }


        }














    }
}