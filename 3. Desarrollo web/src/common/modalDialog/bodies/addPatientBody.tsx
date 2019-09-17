import React from 'react';
import BaseBody from './baseBody';
import Patient from "../../../entities/patient";
import City from '../../../entities/city';
import Form from 'react-bootstrap/Form';
import { ReplaceProps, BsPrefixProps } from 'react-bootstrap/helpers';
import { FormControlProps } from 'react-bootstrap/FormControl';
import FormGroup from '../../formGroup';
import DayPickerInput from 'react-day-picker/DayPickerInput';
import CityService from '../../../services/cityService';
import 'react-day-picker/lib/style.css';

export interface AddPatientBodyState {
    patient: Patient;
    cities: City[];
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
            DateOfDecease: '',
            Smoker: false,
            CigarrettesDailyConsumption: 0,
            City: null,
            CityId: 1
        },
        cities: [
            {
                Id: 0,
                Name: ''
            }
        ]
    }

    async componentDidMount() {
        let cities = await CityService.getCities();

        this.setState({
            cities: cities
        });
    }

    save = (): Patient => {
        return this.state.patient;
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
        if (date) {
            patient.DateOfBirth = date.toISOString();
            this.setState({
                patient: patient
            });
        }
    }

    private onDeceaseDateChange = (date: Date, modifiers: Object, dayPickerInput: DayPickerInput) => {
        let patient = this.state.patient;
        if (date) {
            patient.DateOfDecease = date.toISOString();
            this.setState({
                patient: patient
            });
        }
    }

    private onSmokerChange = (event: React.FormEvent<ReplaceProps<React.ElementType<HTMLSelectElement>, BsPrefixProps<React.ElementType<HTMLSelectElement>> & FormControlProps>>) => {
        let patient = this.state.patient;
        patient.Smoker = event.currentTarget.selectedOptions[0].attributes.getNamedItem('data-id')!.value === 'true' ? true : false;
        this.setState({
            patient: patient
        });
    }

    private onDailyCigarrettesChange = (event: React.FormEvent<ReplaceProps<React.ElementType<HTMLInputElement>, BsPrefixProps<React.ElementType<HTMLInputElement>> & FormControlProps>>) => {
        let patient = this.state.patient;
        patient.CigarrettesDailyConsumption = event.currentTarget.value ? parseInt(event.currentTarget.value) : 0;
        this.setState({
            patient: patient
        });
    }

    private onCityChange = (event: React.FormEvent<ReplaceProps<React.ElementType<HTMLSelectElement>, BsPrefixProps<React.ElementType<HTMLSelectElement>> & FormControlProps>>) => {
        let patient = this.state.patient;
        patient.CityId = parseInt(event.currentTarget.selectedOptions[0].attributes.getNamedItem('data-id')!.value)
        this.setState({
            patient: patient
        });
    }

    public render() {
        let { patient, cities } = this.state;

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
                    <DayPickerInput onDayChange={this.onBirthDateChange}
                        value={patient.DateOfBirth && new Date(patient.DateOfBirth)}
                        format='DD/MM/YYYY' />
                </FormGroup>
                <FormGroup labelText='Fecha de fallecimiento'>
                    <DayPickerInput onDayChange={this.onDeceaseDateChange}
                        value={patient.DateOfDecease && new Date(patient.DateOfDecease)}
                        format='DD/MM/YYYY' />
                </FormGroup>
                <FormGroup labelText='¿Fumador?'>
                    <Form.Control as='select' onChange={this.onSmokerChange} value='No'>
                        <option data-id={true}>Sí</option>
                        <option data-id={false}>No</option>
                    </Form.Control>
                </FormGroup>
                <FormGroup labelText='Cigarros diaríos'>
                    <Form.Control disabled={!patient.Smoker} as='input' type='number' onChange={this.onDailyCigarrettesChange} />
                </FormGroup>
                <FormGroup labelText='Ciudad'>
                    <Form.Control as='select' onChange={this.onCityChange}>
                        {
                            cities.length > 0 && cities.map(city => {
                                return <option data-id={city.Id}>{city.Name}</option>
                            })
                        }
                    </Form.Control>
                </FormGroup>
            </Form>
        );
    }
}