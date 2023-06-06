using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Versta.Models
{
    public class Sender
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string City { get; set; }
        [NotNull]
        public string Address { get; set; }
        public DateTime DateOfCreate { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Sender() {}
        public Sender(string city, string adress)
        {
            this.City = city;
            this.Address = adress;
            this.DateOfCreate = DateTime.Now;
        }
    }
}
