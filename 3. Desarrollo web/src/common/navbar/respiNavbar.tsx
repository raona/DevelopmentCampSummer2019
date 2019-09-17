import React from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import respiNavItem from '../../entities/respiNavItem';
import NavbarItem from './navbarItem';

export interface respiNavbarProps {
    respiNavItems: respiNavItem[];
    defaultActiveKey?: string;
    handleNavBarSelect?(eventKey: string): void;
}

export default class RespiNavbar extends React.Component<respiNavbarProps, {}> {
    public render() {
        let { handleNavBarSelect, respiNavItems, defaultActiveKey } = this.props;

        return (
            <Navbar bg='light' expand='lg'>
                <Navbar.Brand>Respitron</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto" onSelect={handleNavBarSelect} defaultActiveKey={defaultActiveKey}>
                        {
                            respiNavItems.map(item => {
                                return <NavbarItem navbarItem={item} key={item.key} />
                            })
                        }
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}