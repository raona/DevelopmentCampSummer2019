import React from 'react';
import Table from 'react-bootstrap/Table';
import Patient from '../entities/patient';

export interface RespiTableProps {
    headers: string[];
    rows?: Patient[];
}

export default class RespiTable extends React.Component<RespiTableProps, {}> {
    public render() {
        let { headers, rows } = this.props;

        return (
            <Table>
                {
                    headers.length > 0 &&
                    <thead>
                        <tr>
                            {
                                headers.map(header => {
                                    return <th key={header}>{header}</th>
                                })
                            }
                        </tr>
                    </thead>
                }
                {
                    rows && rows.length > 0 &&
                    <tbody>
                        {
                            rows.map((row: Patient, index) => {
                                return <tr key={index}>
                                    {
                                        Object.values(row).length > 0 && Object.values(row).map((column, index) => {
                                            return <td key={index}>{column !== null && column.toString()}</td>
                                        })
                                    }
                                </tr>
                            })
                        }
                    </tbody>
                }
            </Table>
        );
    }
}