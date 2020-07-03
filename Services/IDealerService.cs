using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAPIDapper.Dtos;
using CoreAPIDapper.ServiceResponse;

namespace CoreAPIDapper.Services
{
    public interface IDealerService
    {
          Task<ServiceResponse<List<GetDealerDto>>> GetAllDealers();
          Task<ServiceResponse<GetDealerDto>> GetDealerByDealerNo(int dealerNo);
    }
}