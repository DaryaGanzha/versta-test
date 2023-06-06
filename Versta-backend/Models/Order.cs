using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Versta.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotNull]
        public int SenderId { get; set; }
        public Sender? Sender { get; set; }
        [NotNull]
        public int RecipientId { get; set; }
        public Recipient? Recipient { get; set; }
        [NotNull]
        public int CargoId { get; set; }
        public Cargo? Cargo { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public Order() {}
        public Order(int senderId, int recipientId, int cargoId)
        {
            this.DateOfCreate = DateTime.Now;
            this.SenderId = senderId;
            this.RecipientId = recipientId;
            this.CargoId = cargoId;
        }
    }
}
