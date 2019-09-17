import React from "react";
import Patient from '../entities/patient';
import RespiTable from '../common/respiTable';
import Jumbotron from "react-bootstrap/Jumbotron";
import Button from "react-bootstrap/Button";
import ModalDialog from '../common/modalDialog/modalDialog';
import AddPatientBody from '../common/modalDialog/bodies/addPatientBody';
import PatientService from '../services/patientService';

export interface PatientsState {
    patients: Patient[];
    showModal: boolean;
}

export default class Patients extends React.Component<{}, PatientsState> {
    private bodyRef = React.createRef<AddPatientBody>();
    state = {
        patients: [],
        showModal: false
    };

    async componentDidMount() {
        // let patients = await PatientService.getPatients();
        let patients = await PatientService.getPatients();

        this.setState({
            patients: patients
        });
    }

    private onAddPatientRow = () => {
        this.setState({
            showModal: true
        });
    }

    private onModalDialogClose = () => {
        this.setState({
            showModal: false
        });
    }

    public render() {
        let { patients, showModal } = this.state;

        return (
            <>
                <Jumbotron>
                    <div style={{ display: 'inline-block', verticalAlign: 'middle' }}>
                        <h1>Pacientes</h1>
                        <p>
                            Desde esta página podréis consultar y dar de alta pacientes en el sistema
                        </p>
                        <Button variant='primary' onClick={this.onAddPatientRow}>Añadir registro</Button>
                    </div>
                </Jumbotron>
                {
                    patients.length && <RespiTable headers={Object.keys(patients[0])} rows={patients} />
                }
                <ModalDialog show={showModal} body={<AddPatientBody ref={this.bodyRef} />} title='Añadir paciente' onClose={this.onModalDialogClose} bodyRef={this.bodyRef} />
            </>
        );
    }
}