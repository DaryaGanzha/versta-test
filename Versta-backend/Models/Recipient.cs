using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Versta.Models
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string City { get; set; }
        [NotNull]
        public string Address { get; set; }
        public DateTime DateOfCreate { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Recipient() {}
        public Recipient(string city, string address)
        {
            this.City = city;
            this.Address = address;
            this.DateOfCreate = DateTime.Now;
        }
    }
}
