using System.Collections.Generic;
using System.Linq;
using CoreAPIDapper.Models;

namespace CoreAPIDapper.Properties.Services
{
     

    public class DealerService : IDealerService
    {
           private static List<Dealer> dealers = new List<Dealer>{
            new Dealer{DealerNo=222,DealerName="Şensan"},
            new Dealer{ DealerName="Avek",DealerNo=123}
        };
    
        public List<Dealer> GetAllDealers()
        {
           return dealers;
        }

        public Dealer GetDealerByDealerNo(int dealerNo)
        {
            return dealers.FirstOrDefault(x=>x.DealerNo==dealerNo);
        }
    }
}