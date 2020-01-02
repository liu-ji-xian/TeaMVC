using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaMVC.Models;

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
        /// 添加一名商品信息
        /// </summary>
        /// <returns></returns>
        public IActionResult AddGoods()
        {
            return View();
        }
        
    }
}