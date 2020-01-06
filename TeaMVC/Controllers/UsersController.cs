using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaMVC.Models;

namespace TeaMVC.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 显示与查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult Show(string name = "")
        {
            if (name == "")
            {
                List<Users> list = JsonConvert.DeserializeObject<List<Users>>(ApiClient.GetApiResult("get", "Users/GetUsers"));
                return View(list);
            }
            else
            {
                List<Users> list = JsonConvert.DeserializeObject<List<Users>>(ApiClient.GetApiResult("get", "Users/GetUsers?name=" + name));
                return View(list);
            }

        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUsers()
        {
            return View();
        }
        [HttpPost]
        public void AddUsers(Users s)
        {
            int i = int.Parse(ApiClient.GetApiResult("post", "Users/Addusers", s));
            if (i > 0)
            {
                Response.WriteAsync("<script>location.href='/Users/Show'</script>");

            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public IActionResult Update(int id)
        {
            List<Users> list = JsonConvert.DeserializeObject<List<Users>>(ApiClient.GetApiResult("get", "Users/FanTian?id=" + id));
            return View(list);
        }
        [HttpPost]
        public void Update(Users s)
        {
            string i = ApiClient.GetApiResult("put", "Users/UpdateUsers", s);
            if (!string.IsNullOrEmpty(i))
            {
                Response.WriteAsync("<script>location.href='/Users/Show'</script>");
            }          
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="g"></param>
        public IActionResult Enroll()
        {
            return View();
        }
        [HttpPost]
        public void Enroll(Users u)
        {
            int i = int.Parse(ApiClient.GetApiResult("post", "Users/Enroll", u));
            if (i > 0)
            {
                Response.WriteAsync("<script>alert('注册成功');location.href='/Users/Show'</script>");
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Login(string username, string pwd)
        //{
        //    string json = ApiClient.GetApiResult("get", $"Users/Login?UNo={username}&UPass={pwd}");
        //    if (!string.IsNullOrEmpty(json))
        //    {
        //        HttpContext.Session.SetString("user", json);
        //        return Redirect("/OrdersMoney/Index");
        //    }
        //    return View();
        //}
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void Login(string UNo, string UPass)
        {
            string json = ApiClient.GetApiResult("get", $"Users/Login?UNo={UNo}&UPass={UPass}");
            if (!string.IsNullOrEmpty(json))
            {
                Response.WriteAsync("<script>alert('登陆成功！');location.href='/OrdersMoney/Index'</script>");
            }
            else
            {
                Response.WriteAsync("<script>alert('登陆失败！！！！！！');location.href='/Users/Login'</script>");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}