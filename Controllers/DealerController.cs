using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPIDapper.Dtos;
using CoreAPIDapper.Models;
using CoreAPIDapper.Services;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _dealerService.GetAllDealers());
        }
        [HttpGet("{dealerNo}")]
        public async Task<IActionResult> GetSingle(int dealerNo)
        {
            return Ok(await _dealerService.GetDealerByDealerNo(dealerNo));
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddDealerDto newDealer )
        {
            return Ok(await _dealerService.AddDealer(newDealer));
        }
    }
}