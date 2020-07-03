using System.Collections.Generic;
using System.Linq;
using CoreAPIDapper.Models;
using CoreAPIDapper.Properties.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPIDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealerController : ControllerBase
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;

        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_dealerService.GetAllDealers());
        }
        [HttpGet("{dealerNo}")]
        public IActionResult GetSingle(int dealerNo)
        {
            return Ok(_dealerService.GetDealerByDealerNo(dealerNo));
        }
    }
}