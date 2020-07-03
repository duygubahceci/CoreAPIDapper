using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPIDapper.Models;
using CoreAPIDapper.Properties.Services.ServiceResponse;

namespace CoreAPIDapper.Properties.Services
{
     

    public class DealerService : IDealerService
    {
           private static List<Dealer> dealers = new List<Dealer>{
            new Dealer{DealerNo=222,DealerName="Şensan"},
            new Dealer{ DealerName="Avek",DealerNo=123}
        };

        public async Task<ServiceResponse<List<Dealer>>> GetAllDealers() 
        {
          ServiceResponse<List<Dealer>> serviceResponse = new ServiceResponse<List<Dealer>>();
          serviceResponse.Data= dealers;
          return serviceResponse;
}
        public async Task<ServiceResponse<Dealer>> GetDealerByDealerNo(int dealerNo)
        {
           ServiceResponse<Dealer> serviceResponse = new ServiceResponse<Dealer>();
           serviceResponse.Data= dealers.FirstOrDefault(x=>x.DealerNo==dealerNo);
            return serviceResponse;
        }

        
    }
}