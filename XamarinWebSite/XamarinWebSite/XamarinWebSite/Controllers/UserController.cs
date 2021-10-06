using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using XamarinWebSite.Services;

namespace XamarinWebSite.Controllers
{
    public class UserController : ApiController
    {
        // GET: User

        private XamarinService XamarinService;

        public UserController()
        {

            XamarinService = new XamarinService();
        }
        
       
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
       
        {
           
            return Ok(XamarinService.getUsers());

        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(XamarinService.getUserByID(id));

        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string username, string password)
        {
            return Ok(XamarinService.loginFunction(username,password));

        }

    }
}