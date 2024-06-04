namespace Task.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<InvoiceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InvoiceDbContext context)
        {
            context.Users.AddOrUpdate(
           u => u.Username,
           new User { Username = "admin", Password = EncryptionHelper.Encrypt("admin123") },
           new User { Username = "user", Password = EncryptionHelper.Encrypt("user123"), SessionExpiry = DateTime.Now.AddHours(3), SessionToken = "user-token" }
       );
            //            context.Items.AddOrUpdate(
            //u=>u.Name,
            //new Item {Id=1, Name="اجبان"},
            //new Item {Id=2, Name = "لحوم" }
            //                );
            //            context.products.AddOrUpdate(
            //   u => u.Name,
            //   new Product { Name = "جبنه رومي",Price=67,ItemId=1 },
            //   new Product { Name = "لحم دجاج",Price=90,ItemId=2 }
            //                   );

            //            context.Clients.AddOrUpdate(
            //   u => u.FullName,
            //   new Client { FullName = "هدى عبد الجواد", Phone = "01010342356", Address = "الفيوم" },
            //   new Client { FullName = "احمد محمد", Phone = "01254678943", Address = "القاهرة" }
            //                   );

             }
        }
}
