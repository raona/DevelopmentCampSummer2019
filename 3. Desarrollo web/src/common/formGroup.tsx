import React from 'react';
import Form from 'react-bootstrap/Form';

export interface FormGroupProps {
    labelText: string;
}

export default class FormGroup extends React.Component<FormGroupProps, {}> {
    public render() {
        let { labelText } = this.props;

        return (
            <Form.Group>
                <Form.Label>{labelText}</Form.Label>
                {
                    this.props.children
                }
            </Form.Group>
        );
    }
}