using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server1.Models;
using Server1.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Threads.InitReadThreads();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Start()
        {
            for (int i = 0; i < 8; i++)
            {
                Thread waiterThread = new Thread(new ThreadStart(QWriter.WriteQueue));
                waiterThread.Start();
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult PutData([FromBody] DataItem data)
        {
            ResultData.AddItem(data);
            return Ok();
        }

        public IActionResult GetItems()
        {
            return Ok(ResultData.GetData());
        }

    }
}
