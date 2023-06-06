import { Component } from "react";
import '../Styles/OrderList.css'
import OrderDetails from "./OrderDetails";

export default class OrderList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Orders: [],
            showOrderDetails: false,
            selectedOrder: null,
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleOrderDetailsClose = this.handleOrderDetailsClose.bind(this);
    }

    componentDidMount() {
        this.getOrders();
    }

    getOrders() {
        fetch("https://localhost:7204/api/orders/getAll")
            .then((response) => response.json())
            .then((data) => {
                this.setState({ Orders: data });
            })
            .catch((error) => {
                console.error("Error:", error);
        });
    }

    handleSubmit(order) {
        this.setState({
          showOrderDetails: true,
          selectedOrder: order,
        });
      }

    handleOrderDetailsClose() {
        this.setState({
          showOrderDetails: false,
          selectedOrder: null,
        });
    }
    
    render() {
        const { Orders, showOrderDetails, selectedOrder } = this.state;

        return (
            <div className="orderListContainer">
                <div>
                    <h4>Заказы</h4>
                    <table className="ordersTable">
                        <thead>
                            <tr className="orderLine">
                                <td>№ Заказа</td>
                                <td>Город отправителя</td>
                                <td>Адрес отправителя</td>
                                <td>Город получателя</td>
                                <td>Адрес получателя</td>
                                <td>Вес груза(кг)</td>
                                <td>Дата забора груза</td>
                            </tr>
                        </thead>
                        <tbody>
                            {Orders.map((order) => (
                                <tr className="orderLine">
                                    <td>
                                        {order.number}
                                        <button 
                                            type="submit" 
                                            className="btn btn-secondary"
                                            onClick={() => this.handleSubmit(order)}
                                        >
                                            Подробнее
                                        </button>
                                    </td>
                                    <td>{order.senderCity}</td>
                                    <td>{order.senderAddress}</td>
                                    <td>{order.recipientCity}</td>
                                    <td>{order.recipientAddress}</td>
                                    <td>{order.cargoWeight}</td>
                                    <td>{order.cargoShippingDate}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
                {showOrderDetails && (

                <div className="orderDetailsOverlay">
                    <div className="orderDetailsPopup">
                        <OrderDetails
                        order={selectedOrder}
                        onClose={this.handleOrderDetailsClose}
                        />
                    </div>
                </div>
                )}
            </div>
        )
    }
}