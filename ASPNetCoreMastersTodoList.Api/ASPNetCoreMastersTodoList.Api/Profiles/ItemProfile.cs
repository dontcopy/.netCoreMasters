using ASPNetCoreMastersTodoList.Api.ApiModels;
using AutoMapper;
using DomainModels;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Profiles
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemCreateApiModel, ItemDTO>();
            CreateMap<ItemUpdateApiModel, ItemDTO>();
            CreateMap<ItemDTO, ItemFetchApiModel>();
            CreateMap<Item, ItemDTO > ().ReverseMap();
        }
    }
}
