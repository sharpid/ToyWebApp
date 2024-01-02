using ToyWebApp.Helper;

namespace ToyWebApp;
public class Program
{
    public static IConfigurationBuilder ConfigurationBuilder { get; set; }
    public static IConfiguration Configuration { get { return ConfigurationBuilder.Build(); } }
    public static void Main(string[] args)
    {
        ConfigurationBuilder = CreateConfigurationBuilder();
        var host_builder = CreateHostBuilder(args);
        var host = host_builder.Build();
        host.Run();
    }

    public static IConfigurationBuilder CreateConfigurationBuilder() 
        => new ConfigurationBuilder().AddJsonFile("test.json", optional: true);

    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(web => { web.UseStartup<Startup>(); })
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddConfiguration(Configuration);
                ConfigurationBuilder.AddConfiguration(config.Build());
            });

}
