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
using Microsoft.EntityFrameworkCore;

namespace SFFAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using (var db = new MyDbContext())
            // {
            //     var para = new MovieModel { Name = "Parasit", Category = Category.Horror, Quantity = 10 };
            //     db.Add(para);
            //     db.SaveChanges();

            //     var hob = new MovieModel { Name = "The Hobbit", Category = Category.Action, Quantity = 10 };
            //     db.Add(hob);
            //     db.SaveChanges();

            //     var sf = new MovieStudioModel { Name = "SF Bio", Location = "Borås" };
            //     sf.AddMovie(hob);
            //     sf.AddMovie(para);
            //     sf.AddMovie(para);

            //     db.Add(sf);
            //     db.SaveChanges();

            //     var df = new MovieStudioModel { Name = "Danske Bio", Location = "Copenhagen" };
            //     df.AddMovie(hob);
            //     df.AddMovie(para);

            //     db.Add(df);
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
