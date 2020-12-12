using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Curso
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Data.ApplicationContext();

            // db.Database.Migrate();
            var existe = db.Database.GetPendingMigrations().Any();
            if (existe)
            {
                //
            }
            Console.WriteLine("Hello World!");
        }
    }
}
