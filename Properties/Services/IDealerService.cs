using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAPIDapper.Models;
using CoreAPIDapper.Properties.Services.ServiceResponse;

namespace CoreAPIDapper.Properties.Services
{
    public interface IDealerService
    {
          Task<ServiceResponse<List<Dealer>>> GetAllDealers();
          Task<ServiceResponse<Dealer>> GetDealerByDealerNo(int dealerNo);
    }
}