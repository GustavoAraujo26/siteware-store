﻿using Microsoft.Data.SqlClient;
using Moq;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using SitewareStore.Tests.FakeData;

namespace SitewareStore.Tests.Mocks
{
    internal static class PromotionRepositoryMock
    {
        public static Mock<IPromotionRepository> BuildSuccess()
        {
            var mock = new Mock<IPromotionRepository>();

            mock.Setup(x => x.Save(It.IsAny<SqlConnection>(), It.IsAny<Promotion>()))
                .Returns(Task.CompletedTask);

            mock.Setup(x => x.Delete(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            mock.Setup(x => x.ListAll(It.IsAny<SqlConnection>()))
                .ReturnsAsync(PromotionFakeData.BuildDtoList());

            mock.Setup(x => x.ListActives(It.IsAny<SqlConnection>()))
                .ReturnsAsync(PromotionFakeData.BuildDtoList());

            mock.Setup(x => x.Get(It.IsAny<SqlConnection>(), It.IsAny<Guid>()))
                .ReturnsAsync(PromotionFakeData.BuildFullPriceByQuantity());

            return mock;
        }
    }
}