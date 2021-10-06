using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using XamarinWebSite.Models;
using XamarinWebSite.Services;

namespace XamarinWebSite.Controllers
{
    public class CarController : ApiController
    {
        private XamarinService XamarinService;

        public CarController()
        {

            XamarinService = new XamarinService();
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(XamarinService.getCars());

        }
        
    }
}