using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server2.Models;
using Server2.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
            SendThreads.InitThreads();
        }

        [HttpPost]
        public IActionResult Post(DataItem data)
        {
            WorkStack.PushDataItem(data);
            return Ok();
        }
    }
}
