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
    public class ClientController : Controller
    {
        public IActionResult Index(string id)
        {
            string url;
            if (id != null)
            {
                url = "https://localhost:44346/client/SelOrder?id=" + id;
            }
            else
            {
                url = "https://localhost:44346/client/SelOrders";
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage message = client.GetAsync(url).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            List<Orders> list = JsonConvert.DeserializeObject<List<Orders>>(result);
            return View(list);
        }

        #region 显示
        //public List<Orders> Select()
        //{

        //    return list;
        //}

        #endregion

        #region 显示

        public IActionResult OrIndex(string id)
        {
            string url = "https://localhost:44346/client/OrdersInfo?id=" + id;
            HttpClient client = new HttpClient();
            HttpResponseMessage message = client.GetAsync(url).Result;
            string result = message.Content.ReadAsStringAsync().Result;
            List<OGModel> list = JsonConvert.DeserializeObject<List<OGModel>>(result);
            return View(list);
        }
        //public List<OGModel> OrIndex(string id)
        //{

        //    return list;
        //}

        #endregion
    }
}