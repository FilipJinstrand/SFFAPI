using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SFFAPI.Context;
using SFFAPI.Models;

namespace SFFAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using (var db = new MyDbContext())
            // {
            //     var para = new MovieModel { Name = "Parasit", Quantity = 5, Category = Category.Horror };
            //     db.Add(para);
            //     db.SaveChanges();

            //     var sf = new MovieStudioModel { Name = "SF Bio", Location = "Borås" };
            //     sf.AddMovie(para);
            //     db.Add(sf);
            //     db.SaveChanges();
            // }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
