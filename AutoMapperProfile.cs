using AutoMapper;
using CoreAPIDapper.Models;
using CoreAPIDapper.Dtos;

 namespace CoreAPIDapper
 {
     public class AutoMapperProfile : Profile
     {
         public AutoMapperProfile()
         {
         CreateMap<Dealer,GetDealerDto>();   
         CreateMap<AddDealerDto,Dealer>();
         }
     }

 }