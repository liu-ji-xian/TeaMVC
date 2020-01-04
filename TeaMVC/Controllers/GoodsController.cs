using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaMVC.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TeaMVC.Controllers
{
    public class GoodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowGoods(string name)
        {
            string url;
            if (name!=null)
            {
                url = "https://localhost:44346/Goods/ShowGoods?name=" + name;
            }
            else
            {
                url = "https://localhost:44346/Goods/ShowGoods";
            }
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpRequest = httpClient.GetAsync(url).Result;
            string str = httpRequest.Content.ReadAsStringAsync().Result;
            List<Goods> list = JsonConvert.DeserializeObject<List<Goods>>(str);
            return View(list);
        }

        /// <summary>
        /// 添加一件商品信息
        /// </summary>
        /// <returns></returns>
        public IActionResult AddGoods()
        {
            return View();
        }
        [HttpPost]
        public void AddGoods(Goods g)
        {
            string url = "https://localhost:44346/Goods/AddGoods";
            string str = JsonConvert.SerializeObject(g);
            HttpContent content = new StringContent(str);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage message = httpClient.PostAsync(url, content).Result;
            string stu = message.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt32(stu);
            if (i > 0)
            {
                Response.WriteAsync("<script>alert('添加成功');location.href='/Goods/ShowGoods'</script>");
            }
        }


        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <returns></returns>
        public IActionResult UpGoods()
        {
            return View();
        }
        [HttpPost]
        public void UpGoods(Goods g, string id)
        {
            string url = "https://localhost:44346/Goods/UPGoods?id="+id;
            string str = JsonConvert.SerializeObject(g);
            HttpContent content = new StringContent(str);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage message = httpClient.PostAsync(url, content).Result;
            string stu = message.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt32(stu);
            if (i > 0)
            {
                Response.WriteAsync("<script>alert('保存成功');location.href='/Goods/ShowGoods'</script>");
            }
        }

        [HttpGet]
        public void UpStateOne(string id)
        {
            string url = "https://localhost:44346/Goods/UPStateOne?id="+id;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage message = httpClient.GetAsync(url).Result;
            string stu = message.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt32(stu);
            if (i > 0)
            {
                Response.WriteAsync("<script>alert('上架成功');location.href='/Goods/ShowGoods'</script>");
            }
        }


        [HttpGet]
        public void UpStateTwo(string id)
        {
            string url = "https://localhost:44346/Goods/UPStateTwo?id=" + id;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage message = httpClient.GetAsync(url).Result;
            string stu = message.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt32(stu);
            if (i > 0)
            {
                Response.WriteAsync("<script>alert('下架成功');location.href='/Goods/ShowGoods'</script>");
            }
        }


    }
}