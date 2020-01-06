using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaMVC.Models;
using Newtonsoft.Json;

namespace TeaMVC.Controllers
{
    public class OrdersMoneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }

        /// <summary>
        /// 当天成交额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public decimal GetSumMoneyByDay()
        {
           decimal i= Convert.ToDecimal(APIClient.GetApiResult("get", "GetSumMoneyByDay"));
            return i;
        }

        /// <summary>
        /// 当天成交量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetSuccerSumByDay()
        {
            var i = APIClient.GetApiResult("get", "GetSuccerSumByDay");
            return i;
        }
        /// <summary>
        /// 当天下单量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetOrdersCountByDay()
        {
            var i = APIClient.GetApiResult("get", "GetOrdersCountByDay");
            return i;
        }

        /// <summary>
        /// 本月下单量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetOrdersCountByMonth()
        {
            var i = APIClient.GetApiResult("get", "GetOrdersCountByMonth");
            return i;
        }

        /// <summary>
        /// 本月成交量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetSuccessCountByMonth()
        {
            var i = APIClient.GetApiResult("get", "GetSuccessCountByMonth");
            return i;
        }

        /// <summary>
        ///本月成交额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetOrdersMoneyByMonth()
        {
            var i = APIClient.GetApiResult("get", "GetOrdersMoneyByMonth");
            return i;
        }

        /// <summary>
        /// 订单列表(按时间从晚到早排序)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Orders> OrderListByTime()
        {
            List<Orders> i = JsonConvert.DeserializeObject<List<Orders>>(APIClient.GetApiResult("get", "OrderListByTime"));
            return i;
        }
    }
}