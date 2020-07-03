using System.Collections.Generic;
using CoreAPIDapper.Models;

namespace CoreAPIDapper.Properties.Services
{
    public interface IDealerService
    {
         List<Dealer> GetAllDealers();
         Dealer GetDealerByDealerNo(int dealerNo);
    }
}