import { Container, Nav, Navbar, NavLink } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Component } from "react";
import '../Styles/Header.css'
import OrderCreation from "../Pages/OrderCreation";
import OrderList from "../Pages/OrderList";

export default class Header extends Component {
    render() {
        return (
            <div>
                <Navbar fixed="top" collapseOnSelect expand="md" bg="dark" variant="dark">
                    <Container>
                        <Navbar.Brand href="/">
                            Онлайн Заказ
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                        <Navbar.Collapse id="responsive-navbar-nav">
                            <Nav className="mr-auto">
                                <NavLink href="/createOrder">Новый заказ</NavLink>
                                <NavLink href="/orderList">Список заказов</NavLink>
                            </Nav>
                        </Navbar.Collapse>
                    </Container>
                </Navbar>
                <BrowserRouter>
                    <Routes>
                        <Route path='/createOrder' exact element={<OrderCreation/>} />
                        <Route path='/orderList' exact element={<OrderList/>} />
                    </Routes>
                </BrowserRouter>
            </div>
        )
    }
}