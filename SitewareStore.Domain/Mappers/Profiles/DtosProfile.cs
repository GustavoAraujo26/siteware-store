﻿using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Mappers.TypeConverters.DTOs;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.Profiles
{
    /// <summary>
    /// Configuração dos conversores de DTO's
    /// </summary>
    internal class DtosProfile : Profile
    {
        public DtosProfile()
        {
            CreateMap<List<PromotionModel>, List<PromotionListDTO>>()
                .ConvertUsing<PromotionListDtoTypeConverter>();

            CreateMap<Product, ProductDTO>()
                .ConvertUsing<ProductDtoTypeConverter>();

            CreateMap<Promotion, PromotionDTO>()
                .ConvertUsing<PromotionDtoTypeConverter>();

            CreateMap<ShoppingCart, List<ShoppingCartItemDTO>>()
                .ConvertUsing<ShoppingCartItemDtoTypeConverter>();

            CreateMap<ShoppingCart, ShoppingCartDTO>()
                .ConvertUsing<ShoppingCartDtoTypeConverter>();
        }
    }
}
