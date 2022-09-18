using System;

namespace Module6HW5.Models
{
    public class Teapot
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string ManufacturerCountry { get; set; }

        public double Capacity { get; set; }

        public double Price { get; set; }

        public int WarrantyInMonths { get; set; }

        public string ImgUrl { get; set; }
    }
}
