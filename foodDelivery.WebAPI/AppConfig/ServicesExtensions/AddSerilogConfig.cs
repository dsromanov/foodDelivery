using Serilog;

namespace foodDelivery.WebAPI.AppConfiguration.ServicesExtensions{
    public static partial class ServicesExtensions{

        public static void AddSerilogConfig(this WebApplicationBuilder builder){
            builder.Host.UseSerilog((context, loggerConfiguration)=>
            {
                loggerConfiguration.Enrich.WithCorrelationId().ReadFrom.Configuration(context.Configuration);
            });
            builder.Services.AddHttpContextAccessor();
        }

    }
}