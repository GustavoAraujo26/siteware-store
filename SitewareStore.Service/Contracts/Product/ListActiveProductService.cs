﻿using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Service.Contracts.Product
{
    public class ListActiveProductService : IListActiveProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IRepositoryBase repositoryBase;

        public ListActiveProductService(IProductRepository productRepository, IRepositoryBase repositoryBase)
        {
            this.productRepository = productRepository;
            this.repositoryBase = repositoryBase;
        }

        public async Task<InternalResponse<ProductListDTO>> Execute()
        {
            try
            {
                using (var db = repositoryBase.CreateDbConnection())
                {
                    var productList = await productRepository.ListActives(db);

                    return InternalResponse<ProductListDTO>.Success(productList);
                }
            }
            catch(Exception ex)
            {
                return InternalResponse<ProductListDTO>.Error(ex);
            }
        }
    }
}
