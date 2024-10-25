using AutoMapper;
using Talabat.APIs.DTOs;
using Talabat.Core.Entities;

namespace Talabat.APIs.Helpers
{
    public class MappingPofiles:Profile
    {

        public MappingPofiles()
        {
            

            CreateMap<Product,ProductToReturnDto>()
                .ForMember(d=>d.Brand,O=>O.MapFrom(s=>s.Brand.Name))
                .ForMember(d=>d.Category,O=>O.MapFrom(s=>s.Category.Name))
                /*.ForMember(d=>d.PictureUrl,O=>O.MapFrom(s=>$"{configuration["https://localhost:7152"]}/{s.PictureUrl}"))*/
                .ForMember(d=>d.PictureUrl , O=>O.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
