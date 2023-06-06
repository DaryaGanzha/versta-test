import React from "react";

function OrderDetails(props) {
  const { order, onClose } = props;

  return (
    <div className="orderDetails">
      <h4>Информация о заказе</h4>
      <p>Номер заказа: {order.number}</p>
      <p>Город отправителя: {order.senderCity}</p>
      <p>Адрес отправителя: {order.senderAddress}</p>
      <p>Город получателя: {order.recipientCity}</p>
      <p>Адрес получателя: {order.recipientAddress}</p>
      <p>Вес груза(кг): {order.cargoWeight}</p>
      <p>Дата забора груза: {order.cargoShippingDate}</p>
      <button className="btn btn-secondary" onClick={onClose}>Закрыть</button>
    </div>
  );
}

export default OrderDetails;