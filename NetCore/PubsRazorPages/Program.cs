using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using PubsRepository.Context;
using PubsRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace PubsRazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<PubsContext>();
            //        List<Author> authors = context.Authors.Include(a => a.Titles).ThenInclude(ta => ta.Title).ToList();
            //        List<Title> titles = context.Titles.Include(t => t.Publisher).ToList();
            //        Title title = context.Titles.Include(t => t.Authors).Include(t => t.Publisher).FirstOrDefault(t => t.TitleID == "BU1032");
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
