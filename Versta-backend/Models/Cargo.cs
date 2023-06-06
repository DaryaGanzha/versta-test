using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Versta.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public double Weight { get; set; }
        [NotNull]
        public DateTime ShippingDate { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public Order? Order { get; set; }
        public Cargo() {}
        public Cargo(double weight, DateTime shippingDate)
        {
            this.DateOfCreate = DateTime.Now;
            this.Weight = weight;
            this.ShippingDate = shippingDate;
        }
    }
}
