using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IUH.TOURBOOKING.WEBSITE.Common;
using IUH.TOURBOOKING.WEBSITE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IUH.TOURBOOKING.WEBSITE.ViewComponents
{
    public class Domestic : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var servicename = "api/LsTourGroups/getDomestic";
            var data = "";
            string uri = string.Format("https://{0}:{1}/{2}", "localhost", "44317", servicename);
            Dictionary<string, string> pHeaders = new Dictionary<string, string>();
            var obj = ServiceClient.Request(HttpMethod.Get, uri, data, pHeaders).Result;
            var rs = obj.Content.ReadAsStringAsync().Result;
            List<LsTourGroup> theme = new List<LsTourGroup>();
            try
            {
                theme = JsonConvert.DeserializeObject<List<LsTourGroup>>(rs);
            }
            catch (Exception ex)
            {

            }
            return View(theme);
        }
    }
}