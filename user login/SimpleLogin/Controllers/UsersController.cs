using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Data;
using System.Reflection;



namespace SimpleLogin.Controllers
{
    public class UsersController : Controller
    {
        [Route("api/Admin")]

      
        [HttpGet("Test")]
        public ActionResult<string> Test()
        {

            return ("hi suabsh");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}