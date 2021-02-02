using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("Error/{statuscode}")]
        public IActionResult StatusCodeHandler(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrMsg = "Oops...The Resource requested by you is not found";
                    break;
            }
            return View("Error");
        }
    }
}
