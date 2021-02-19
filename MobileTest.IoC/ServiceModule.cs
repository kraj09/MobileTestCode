using MobileTest.Domain;
using MobileTest.Domain.Entities;
using MobileTest.Domain.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTest.IoC
{
    public class ServiceModule
    {
        private readonly Container container;

        public ServiceModule()
        {
            container = new Container();
            container.Register<IFeedApiService, FeedApiService>(Lifestyle.Singleton);

            container.Verify();
        }

        public async Task<List<FeedModel>> GetFeeds()
        {
            var instance = container.GetInstance<IFeedApiService>();
            return await instance.CallApi();
        }
    }
}
