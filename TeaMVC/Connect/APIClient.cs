﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TeaMVC.Models
{
    
    public class APIClient
    {

        /// <summary>
        /// 封装WebApi的方法
        /// </summary>
        /// <param name="verbs">请求的动作名称(get/post/put/delete)</param>
        /// <param name="actionName">请求的api方法名称</param>
        /// <param name="obj">添加或者修改需要传入的参数</param>
        /// <returns>返回json字符串</returns>
        public static string GetApiResult(string verbs, string actionName, Object obj = null)
        {
            Task<HttpResponseMessage> task = null;
            string json = "";
            //创建一个Http客户端对象
            HttpClient client = new HttpClient();
            //指定访问WebApi的uri地址
            client.BaseAddress = new Uri("https://localhost:44346/api/ordersmoney/");
            /*根据不同的动作执行不同的方法*/
            switch (verbs.ToLower())
            {
                case "get":
                    task = client.GetAsync(actionName);
                    break;
                case "post":
                    HttpContent content_post = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    task = client.PostAsync(actionName, content_post);
                    break;
                case "put":
                    HttpContent content_put = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    task = client.PutAsync(actionName, content_put);
                    break;
                case "delete":
                    task = client.DeleteAsync(actionName);
                    break;
                default:
                    break;
            }
            //等待请求的过程
            task.Wait();
            //接收响应的结果
            var response = task.Result;
            //判断响应的状态码是成功时候
            if (response.IsSuccessStatusCode)
            {
                //从响应对象的内容中读取字符串
                var read = response.Content.ReadAsStringAsync();
                //等待读取的过程
                read.Wait();
                //接收读取的结果-json
                json = read.Result;
            }
            return json;
        }
    }
}
