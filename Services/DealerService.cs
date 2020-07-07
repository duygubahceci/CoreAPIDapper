using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIDapper.Dtos;
using CoreAPIDapper.Models;
using CoreAPIDapper.ServiceResponse;
using Dapper;

namespace CoreAPIDapper.Services
{


    public class DealerService : IDealerService
    {
        private static List<Dealer> dealers = new List<Dealer>{
            new Dealer{DealerNo=222,DealerName="Şensan"},
            new Dealer{ DealerName="Avek",DealerNo=123}
        };

        private readonly string _connectionString;
        private  IDbConnection _connection { get { return new SqlConnection(_connectionString); }}

        private readonly IMapper _mapper;
        public DealerService(IMapper mapper)
        {
            _mapper = mapper;
            _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=OrderManagement; Integrated Security=True";

        }

        public async Task<ServiceResponse<List<GetDealerDto>>> AddDealer(AddDealerDto newDealer)
        {
            ServiceResponse<List<GetDealerDto>> serviceResponse = new ServiceResponse<List<GetDealerDto>>();
            Dealer dealer = _mapper.Map<Dealer>(newDealer);        
        
            using (IDbConnection dbConnection = _connection)
            {
                string query = @" INSERT INTO [dbo].[Dealer]
                            ([DealerNo]
                            ,[DealerName]
                            ,[SearchName])
                                  VALUES
                            (@DealerNo
                            ,@DealerName
                            ,@SearchName)";

                await dbConnection.ExecuteAsync(query, dealer);
            }
            serviceResponse.Data = GetAllDealers().Result.Data;
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetDealerDto>>> GetAllDealers()
        {
            ServiceResponse<List<GetDealerDto>> serviceResponse = new ServiceResponse<List<GetDealerDto>>();
           
            using (IDbConnection dbConnection = _connection)
            {
                var procedure = "fsp_get_Dealers";
               
               var dealers = (dbConnection.QueryAsync<Dealer>(procedure, commandType: CommandType.StoredProcedure).Result);
                          
                serviceResponse.Data = dealers.Select(x => _mapper.Map<GetDealerDto>(x)).ToList();    
            }     
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDealerDto>> GetDealerByDealerNo(int dealerNo)
        {
            ServiceResponse<GetDealerDto> serviceResponse = new ServiceResponse<GetDealerDto>();

            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [DealerNo]
                                    ,[DealerName]
                                    ,[SearchName]
                                FROM [Dealer] (nolock)
                                where DealerNo=@DealerNo";

                var dealer = await dbConnection.QueryFirstOrDefaultAsync<Dealer>(query, new{ @DealerNo = dealerNo });
                serviceResponse.Data = _mapper.Map<GetDealerDto>(dealer);
            }
            return serviceResponse;
        }
    }
}