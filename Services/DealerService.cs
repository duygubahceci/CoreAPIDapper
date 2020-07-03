using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPIDapper.Dtos;
using CoreAPIDapper.Models;
using CoreAPIDapper.ServiceResponse;

namespace CoreAPIDapper.Services
{
     

    public class DealerService : IDealerService
    {
           private static List<Dealer> dealers = new List<Dealer>{
            new Dealer{DealerNo=222,DealerName="Şensan"},
            new Dealer{ DealerName="Avek",DealerNo=123}
        };

        public async Task<ServiceResponse<List<GetDealerDto>>> IDealerService.GetAllDealers()
        {
            ServiceResponse<List<GetDealerDto>> serviceResponse = new ServiceResponse<List<GetDealerDto>>();
          serviceResponse.Data= dealers;
          return serviceResponse;
        }

        public async Task<ServiceResponse<GetDealerDto>> IDealerService.GetDealerByDealerNo(int dealerNo)
        {
             ServiceResponse<GetDealerDto> serviceResponse = new ServiceResponse<GetDealerDto>();
           serviceResponse.Data= dealers.FirstOrDefault(x=>x.DealerNo==dealerNo);
            return serviceResponse;
        }
    }
}