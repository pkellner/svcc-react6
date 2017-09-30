using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImageResize()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public async Task<IActionResult> About([FromServices] INodeServices nodeServices)
        {

            ViewData["ResultFromNode"] = await nodeServices.InvokeAsync<string>("NodeSrc/myNodeModule.js");
            return View(viewName: "About");
        }
    }
}
