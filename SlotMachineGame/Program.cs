using GameEngines.Interfaces;
using GameEngines.Slots;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleSlotMachine;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
        
static IHostBuilder CreateHostBuilder(string[] strings) => 
    Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
          {
              services.AddSingleton<ISlotsGameEngine, SlotsGameEngine>();
              services.AddSingleton<Game>();
          });

try
{
    services.GetRequiredService<Game>().Begin();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}