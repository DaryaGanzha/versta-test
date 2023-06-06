using Microsoft.AspNetCore.Identity;
using Versta.Models;
using Versta.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Versta.Services
{
    public class OrderService
    {
        private ApplicationContext _context;
        public OrderService()
        {
            this._context = new ApplicationContext();
        }

        public bool CreateOrder(OrderData orderData)
        {
            try
            {
                var sender = _context.Senders.Where(s => s.City == orderData.SenderCity && s.Address == orderData.SenderAddress).FirstOrDefault();
                if (sender == null)
                {
                    sender = new Sender(orderData.SenderCity, orderData.SenderAddress);
                    _context.Senders.Add(sender);
                }
                var recipient = _context.Recipients.Where(r => r.City == orderData.RecipientCity && r.Address == orderData.RecipientAddress).FirstOrDefault();
                if (recipient == null)
                {
                    recipient = new Recipient(orderData.RecipientCity, orderData.RecipientAddress);
                    _context.Recipients.Add(recipient);
                }

                _context.SaveChanges();

                string[] validformats = new[] { "dd-MM-yyyy", "yyyy-MM-dd" };
                CultureInfo provider = new CultureInfo("en-US");
                DateTime dateTime = DateTime.ParseExact(orderData.CargoShippingDate, validformats, provider);
                
                var cargo = new Cargo(orderData.CargoWeight, dateTime);
                _context.Cargoes.Add(cargo);
                _context.SaveChanges();
                var order = new Order(sender.Id, recipient.Id, cargo.Id);
                _context.Orders.Add(order);
                _context.SaveChanges();

            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Sender or recipient not found.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Database error.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Order is not created.", ex);
            }

            return true;
        }

        public List<OrderData> GetAllOrders()
        {
            var ordersData = new List<OrderData>(); 
            var orders = _context.Orders.ToList();
            Console.WriteLine(orders);
            
            foreach(var order in orders)
            {
                var orderData = new OrderData();
                orderData.Number = order.Id;
                var sender = _context.Senders.Where(s => s.Id == order.SenderId).FirstOrDefault();
                orderData.SenderCity = sender.City;
                orderData.SenderAddress = sender.Address;
                var recipient = _context.Recipients.Where(r => r.Id == order.RecipientId).FirstOrDefault();
                orderData.RecipientCity = recipient.City;
                orderData.RecipientAddress = recipient.Address;
                var cargo = _context.Cargoes.Where(c => c.Id == order.CargoId).FirstOrDefault();
                orderData.CargoWeight = cargo.Weight;
                orderData.CargoShippingDate = cargo.ShippingDate.ToShortDateString();
                ordersData.Add(orderData);
            }
            return ordersData;
        }
    }
}
