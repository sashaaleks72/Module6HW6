using Microsoft.EntityFrameworkCore;
using Module6HW5.Models;

namespace Module6HW5.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Teapot> Teapots { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teapot>().HasData(
                new Teapot { 
                    Title = "Teapot BOSCH TWK3A013", 
                    ImgUrl = "https://content.rozetka.com.ua/goods/images/big_tile/10648417.jpg",
                    Capacity = 1.7,
                    Description = "Safety in 3 dimensions: automatic shutdown, protection against " +
                    "leakage and overheating, LED indication.",
                    ManufacturerCountry = "China",
                    Price = 1199,
                    Quantity = 8,
                    WarrantyInMonths = 12
                },
                new Teapot
                {
                    Title = "Teapot TEFAL LOFT KO250830",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/64732971.jpg",
                    Capacity = 1.7,
                    Description = "Inspired by traditional British ceramics, the Loft teapot's stunning " +
                    "fluted lines are elegantly paired with modern chrome accents for a timeless " +
                    "design that looks great in any kitchen.",
                    ManufacturerCountry = "China",
                    Price = 1299,
                    Quantity = 12,
                    WarrantyInMonths = 24
                },
                new Teapot
                {
                    Title = "Teapot BOSCH TWK3P423",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/19966325.jpg",
                    Capacity = 1.7,
                    Description = "Safety in 3 dimensions: automatic shutdown, protection against " +
                    "leakage and overheating, LED indication.",
                    ManufacturerCountry = "China",
                    Price = 2299,
                    Quantity = 7,
                    WarrantyInMonths = 24
                },
                new Teapot
                {
                    Title = "Teapot Philips Eco HD9365/10",
                    ImgUrl = "https://content1.rozetka.com.ua/goods/images/big_tile/267792323.jpg",
                    Capacity = 1.7,
                    Description = "Prepare hot drinks in no time with 2200W of power",
                    ManufacturerCountry = "China",
                    Price = 2349,
                    Quantity = 13,
                    WarrantyInMonths = 24
                },
                new Teapot
                {
                    Title = "Teapot Philips Viva Collection HD9355/92",
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/274310222.jpg",
                    Capacity = 1.7,
                    Description = "With keep warm function; fast, safe boiling; easy to fill, use and clean",
                    ManufacturerCountry = "China",
                    Price = 2399,
                    Quantity = 7,
                    WarrantyInMonths = 24
                },
                new Teapot
                {
                    Title = "Teapot AENO EK4",
                    ImgUrl = "https://content2.rozetka.com.ua/goods/images/big_tile/248635439.jpg",
                    Capacity = 1.5,
                    Description = "With the AENO EK4 electric kettle, you can boil water in just 5 " +
                    "minutes and have time to prepare tea or coffee for the arrival of guests.",
                    ManufacturerCountry = "China",
                    Price = 1099,
                    Quantity = 9,
                    WarrantyInMonths = 24
                });
        }
    }
}
