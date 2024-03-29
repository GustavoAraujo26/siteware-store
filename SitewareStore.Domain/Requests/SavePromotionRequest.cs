﻿using FluentValidation;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Validators;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição para persistência de promoção
    /// </summary>
    public class SavePromotionRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public SavePromotionRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="observation">Observação</param>
        /// <param name="type">Tipo de promoção</param>
        /// <param name="cutQuantity">Quantidade de corte</param>
        /// <param name="percentage">Porcentagem de desconto</param>
        /// <param name="price">Valor final aplicado</param>
        public SavePromotionRequest(Guid? id, string observation, PromotionType type, 
            int? cutQuantity, decimal? percentage, decimal? price)
        {
            Id = id;
            Observation = observation;
            Type = type;
            CutQuantity = cutQuantity;
            Percentage = percentage;
            Price = price;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Observação
        /// </summary>
        public string Observation { get; set; }

        /// <summary>
        /// Tipo de promoção
        /// </summary>
        public PromotionType Type { get; set; }

        /// <summary>
        /// Quantidade de corte
        /// </summary>
        public int? CutQuantity { get; set; }

        /// <summary>
        /// Porcentagem de desconto
        /// </summary>
        public decimal? Percentage { get; set; }

        /// <summary>
        /// Valor final aplicado
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Realiza validação das informações recebidas
        /// </summary>
        /// <returns>Container-resposta</returns>
        public InternalResponse<SavePromotionRequest> Validate() =>
            new PromotionRequestValidator().Validate(this).FormatResponse<SavePromotionRequest>();
    }
}
