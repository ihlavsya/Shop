﻿using AutoMapper;
using Shop.Products;

namespace Shop;

public class ShopApplicationAutoMapperProfile : Profile
{
    public ShopApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
		CreateMap<ProductDto, CreateProductDto>();
		CreateMap<UpdateProductDto, Product>();
		CreateMap<ProductDto, UpdateProductDto>();
	}
}
