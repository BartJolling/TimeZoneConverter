using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Authentication;
using TimeZoneConverter.Contracts;

namespace TimeZoneConverter;

public class Startup
{
    public const int HTTP_PORT = 8088;
    public const int HTTPS_PORT = 8443;

    // Only used on case that UseRequestHeadersForMetadataAddressBehavior is not used
    public const string HOST_IN_WSDL = "localhost";

    public void ConfigureServices(IServiceCollection services)
    {
        // Enable CoreWCF Services, enable metadata
        // Use the Url used to fetch WSDL as that service endpoint address in generated WSDL 
        services.AddServiceModelServices()
                .AddServiceModelMetadata()
                .AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>()
                .AddSingleton<IAuthenticationSchemeProvider, AuthenticationSchemeProvider>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseServiceModel(builder =>
        {
            // Add the Echo Service
            builder.AddService<TimeZoneConverterService>(serviceOptions =>
            {
                // Set the default host name:port in generated WSDL and the base path for the address 
                serviceOptions.BaseAddresses.Add(new Uri($"http://{HOST_IN_WSDL}/TimeZoneConverter"));
                serviceOptions.BaseAddresses.Add(new Uri($"https://{HOST_IN_WSDL}/TimeZoneConverter"));
            })
            .AddServiceEndpoint<TimeZoneConverterService, ITimeZoneConverter>(new BasicHttpBinding(), "/")
            .AddServiceEndpoint<TimeZoneConverterService, ITimeZoneConverter>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/");

            // Configure WSDL to be available over http & https
            var serviceMetadataBehavior = app.ApplicationServices.GetRequiredService<ServiceMetadataBehavior>();
            serviceMetadataBehavior.HttpGetEnabled = serviceMetadataBehavior.HttpsGetEnabled = true;
        });
    }
}