using MobileTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTest.Domain
{
    public interface IFeedApiService
    {
        Task<List<FeedModel>> CallApi();
    }
}
