import React from "react";
import Nav from "react-bootstrap/Nav";
import respiNavItem from "../entities/respiNavItem";

export interface navbarItemProps {
    navbarItem: respiNavItem;
}

export default class NavbarItem extends React.Component<navbarItemProps, {}> {
    public render() {
        let { navbarItem } = this.props;

        return (
            <Nav.Item>
                <Nav.Link eventKey={navbarItem.key}>{navbarItem.title}</Nav.Link>
            </Nav.Item>
        );
    }
}