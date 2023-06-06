import { Component } from "react";
import '../Styles/OrderCreation.css'
import SuccessfullyCreated from "./SuccessfullyCreated";

export default class OrderCreation extends Component {
    constructor(props) {
        super(props);
        this.state = {
            SenderCity: "",
            SenderAddress: "",
            RecipientCity: "",
            RecipientAddress: "",
            CargoWeight: 0,
            CargoShippingDate: "",
            showSuccessfullyCreated: false
        }
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        })
    }

    handleSuccessfullyCreatedClose() {
        this.setState({
          showSuccessfullyCreated: false,
        });
    }

    successfullyCreatedWindow() {
        this.setState({
            showSuccessfullyCreated: true,
          });
    }

    handleSubmit(event) {
        event.preventDefault();
        const order = {
            SenderCity: this.state.SenderCity,
            SenderAddress: this.state.SenderAddress,
            RecipientCity: this.state.RecipientCity,
            RecipientAddress: this.state.RecipientAddress,
            CargoWeight: this.state.CargoWeight,
            CargoShippingDate: this.state.CargoShippingDate
        }
        console.log(order);
        fetch("https://localhost:7204/api/orders/create", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        })
        .then(response => response.json())
        .then(data => {
            this.successfullyCreatedWindow();
        })
        .catch(error => console.error(error));
    }

    render() {
        const { showSuccessfullyCreated } = this.state;

        return (
            <div className="orderCreationContainer">
                <div className="createBox">
                    <h4 className="head">Создайте заказ</h4>
                    <form onSubmit={this.handleSubmit}>
                        <p><strong>Город отправителя</strong></p>
                        <p><input type="text" step={1} name="SenderCity" value={this.state.SenderCity} onChange={this.handleInputChange} max={1000} min={0} placeholder="Введите город отправителя"/></p>
                        <p><strong>Адрес отправителя</strong></p>
                        <p><input type="text" step={1} name="SenderAddress" value={this.state.SenderAddress} onChange={this.handleInputChange} max={500} min={0} placeholder="Введите адрес отправителя"/></p>
                        <p><strong>Город получателя</strong></p>
                        <p><input type="text" step={1} name="RecipientCity" value={this.state.RecipientCity} onChange={this.handleInputChange} placeholder="Введите город получателя"/></p>
                        <p><strong>Адрес получателя</strong></p>
                        <p><input type="text" name="RecipientAddress" value={this.state.RecipientAddress} onChange={this.handleInputChange} placeholder="Введите адрес получателя"/></p>
                        <p><strong>Вес груза(кг)</strong></p>
                        <p><input type="number" step={0.1} name="CargoWeight" value={this.state.CargoWeight} onChange={this.handleInputChange} placeholder="Введите вес груза"/></p>
                        <p><strong>Дата забора груза</strong></p>
                        <p><input type="date" name="CargoShippingDate" value={this.state.CargoShippingDate} onChange={this.handleInputChange} placeholder="Введите дату забора груза"/></p>
                        <button type="submit" className="btn btn-dark">Добавить</button>
                    </form>
                </div>
                {showSuccessfullyCreated && (

                    <div className="window">
                        <div className="text">
                            <SuccessfullyCreated
                            onClose={this.handleSuccessfullyCreatedClose}
                            />
                        </div>
                    </div>
                )}
            </div>
        )
    }
}