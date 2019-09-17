import React from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import BaseBody from './bodies/baseBody';

export interface ModalDialogProps {
    title: string;
    body: JSX.Element;
    show: boolean;
    bodyRef: React.RefObject<BaseBody>;
    onClose(): void;
}

export interface ModalDialogState {

}

export default class ModalDialog extends React.Component<ModalDialogProps, ModalDialogState> {
    onSaveClick = () => {
        let { bodyRef } = this.props;

        if(bodyRef.current) bodyRef.current.save();
    }
    
    public render() {
        let { title, body, show, onClose } = this.props;

        return (
            <Modal show={show} onHide={onClose}>
                <Modal.Header closeButton>
                    <Modal.Title>{title}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {
                        body
                    }
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={onClose}>Cancelar</Button>
                    <Button variant="primary" onClick={this.onSaveClick}>Guardar</Button>
                </Modal.Footer>
            </Modal>
        );
    }
}