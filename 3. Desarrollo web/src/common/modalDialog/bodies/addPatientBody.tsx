import React from 'react';
import BaseBody from './baseBody';
import Patient from "../../../entities/patient";
import Form from 'react-bootstrap/Form';
import { ReplaceProps, BsPrefixProps } from 'react-bootstrap/helpers';
import { FormControlProps } from 'react-bootstrap/FormControl';
import FormGroup from '../../formGroup';
import DayPickerInput from 'react-day-picker/DayPickerInput';
import 'react-day-picker/lib/style.css';

export interface AddPatientBodyState {
    patient: Patient;
}

export default class AddPatientBody extends React.Component<{}, AddPatientBodyState> implements BaseBody {
    state = {
        patient: {
            Id: 0,
            Name: '',
            Surname: '',
            Gender: null,
            GenderId: 1,
            DateOfBirth: new Date().toISOString(),
            DateOfDecease: new Date().toISOString(),
            Smoker: false,
            CigarrettesDailyConsumption: 0,
            City: null,
            CityId: 1
        }
    }

    save = (): void => {
        console.log(this.state.patient);
    }

    private onNameChange = (event: React.FormEvent<ReplaceProps<React.ElementType<HTMLInputElement>, BsPrefixProps<React.ElementType<HTMLInputElement>> & FormControlProps>>) => {
        let patient = this.state.patient;
        patient.Name = event.currentTarget.value ? event.currentTarget.value : '';
        this.setState({
            patient: patient
        });
    }

    private onSurnameChange = (event: React.FormEvent<ReplaceProps<React.ElementType<HTMLInputElement>, BsPrefixProps<React.ElementType<HTMLInputElement>> & FormControlProps>>) => {
        let patient = this.state.patient;
        patient.Surname = event.currentTarget.value ? event.currentTarget.value : '';
        this.setState({
            patient: patient
        });
    }

    private onGenderChange = (event: React.FormEvent<ReplaceProps<React.ElementType<HTMLSelectElement>, BsPrefixProps<React.ElementType<HTMLSelectElement>> & FormControlProps>>) => {
        let patient = this.state.patient;
        patient.GenderId = parseInt(event.currentTarget.selectedOptions[0].attributes.getNamedItem('data-id')!.value);
        this.setState({
            patient: patient
        });
    }

    private onBirthDateChange = (date: Date, modifiers: Object, dayPickerInput: DayPickerInput) => {
        let patient = this.state.patient;
        patient.DateOfBirth = date.toISOString();
        this.setState({
            patient: patient
        });
    }

    public render() {
        return (
            <Form>
                <FormGroup labelText='Nombre'>
                    <Form.Control as='input' type='text' onChange={this.onNameChange} />
                </FormGroup>
                <FormGroup labelText='Apellidos'>
                    <Form.Control as='input' type='text' onChange={this.onSurnameChange} />
                </FormGroup>
                <FormGroup labelText='Género'>
                    <Form.Control as='select' onChange={this.onGenderChange}>
                        <option data-id={2}>Masculino</option>
                        <option data-id={1}>Femenino</option>
                        <option data-id={3}>Otro</option>
                    </Form.Control>
                </FormGroup>
                <FormGroup labelText='Fecha de nacimiento'>
                    <DayPickerInput onDayChange={this.onBirthDateChange} value={new Date(this.state.patient.DateOfBirth)} format='DD/MM/YYYY' />
                </FormGroup>
            </Form>
        );
    }
}