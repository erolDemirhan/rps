using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RockPaperScissors.Interfaces;
using System;

namespace RockPaperScissors
{
    class Program
    {
        private static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var game = services.GetService<IGame>();
            game.Play();
            Console.ReadKey();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IOutput, Output>();
            services.AddSingleton<IGame, Game>();
            services.AddSingleton<IPlayerFactory, PlayerFactory>();
            services.AddSingleton<IRoundPlayer, RoundPlayer>();
            services.AddSingleton<IWinCalculator, WinCalculator>();
        });
    }
}
