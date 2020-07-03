using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;
        public DealerService(IMapper mapper)
        {
            _mapper = mapper;

        }
    
        public async Task<ServiceResponse<List<GetDealerDto>>> GetAllDealers()
        {
            ServiceResponse<List<GetDealerDto>> serviceResponse = new ServiceResponse<List<GetDealerDto>>();
            serviceResponse.Data =  dealers.Select(c =>_mapper.Map<GetDealerDto>(dealers)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDealerDto>> GetDealerByDealerNo(int dealerNo)
        {
            ServiceResponse<GetDealerDto> serviceResponse = new ServiceResponse<GetDealerDto>();
            serviceResponse.Data =_mapper.Map<GetDealerDto>(dealers.FirstOrDefault(x => x.DealerNo == dealerNo));
            return serviceResponse;
        }
    }
}