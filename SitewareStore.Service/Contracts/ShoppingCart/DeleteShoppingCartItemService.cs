﻿using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class DeleteShoppingCartItemService : IDeleteShoppingCartItemService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IShoppingCartItemRepository cartItemRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public DeleteShoppingCartItemService(IShoppingCartRepository cartRepository, 
            IShoppingCartItemRepository cartItemRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ShoppingCartDTO>> Execute(DeleteShoppingCartItemRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<ShoppingCartDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var cart = await cartRepository.Get(db, request.CartId);
                    if (cart is null)
                        return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o carrinho de compras.");

                    var cartItem = await cartItemRepository.Get(db, request.CartItemId);
                    if (cartItem is null)
                        return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o item do carrinho de compras.");

                    await cartItemRepository.Delete(db, request.CartItemId);

                    cart.RemoveItem(request.CartItemId);

                    var dto = mapper.Map<ShoppingCartDTO>(cart);

                    repositoryBase.CompleteTransaction(transaction);

                    return InternalResponse<ShoppingCartDTO>.Success(dto);
                }
            }
            catch(Exception ex)
            {
                return InternalResponse<ShoppingCartDTO>.Error(ex);
            }
        }
    }
}
