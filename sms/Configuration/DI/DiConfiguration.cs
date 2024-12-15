using sms.Repository;
using sms.Repository.Interfaces;
using sms.Services;
using sms.Services.Interfaces;
using sms.Services.Strategy;

namespace sms.Configuration.DI;

public static class DiConfiguration
{

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ISMSVendorStrategy, SMSVendorStrategy>();

        services.AddScoped<ISend, SMSVendorCYService>();
        services.AddScoped<ISend, SMSVendorGRService>();
        services.AddScoped<ISend, SMSVendorRestService>();
        services.AddScoped<IVendorsLimitationService, VendorsLimitationService>();
        
        services.AddScoped<IMessageRepository, MessageRepository>();
    }
}
