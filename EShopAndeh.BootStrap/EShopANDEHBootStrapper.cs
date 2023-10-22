using EShop.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EShopAndeh.BootStrap
{
    public static class EShopANDEHBootStrapper
    {
        public static void WireUp(IServiceCollection serviceDescriptors,string EShopConnectingString)
        {
            serviceDescriptors.AddDbContext<EShopANDEHContext>(
                optionsAction => {
                    optionsAction
                     .UseSqlServer(EShopConnectingString);
                },ServiceLifetime.Scoped);
        }
    }
}
