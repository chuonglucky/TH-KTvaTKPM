using ASC.Model.Models;
using AutoMapper;

namespace ASC.Web.Areas.Configuration.Models
{
    // 1 reference
    public class MappingProfile : Profile
    {
        // 0 references
        public MappingProfile()
        {
            CreateMap<MasterDataKey, MasterDataKeyViewModel>();
            CreateMap<MasterDataKeyViewModel, MasterDataKey>();
            CreateMap<MasterDataValue, MasterDataValueViewModel>();
            CreateMap<MasterDataValueViewModel, MasterDataValue>();
        }
    }
}