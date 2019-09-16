import React from 'react';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Image from 'react-bootstrap/Image';
import Carousel from 'react-bootstrap/Carousel';

export default class Home extends React.Component<{}, {}> {
    public render() {
        return (
            <>
                <Jumbotron style={{marginBottom: '0px'}}>
                    <Image style={{display: 'inline-block'}} rounded src='https://memenginy.enginyeriauab.cat/wp-content/uploads/2019/02/LogoRaona-1.png' height="170px" />
                    <div style={{display: 'inline-block', verticalAlign: 'middle'}}>
                        <h1>¡Bienvenidos a Respitron!</h1>
                        <p>
                            Usad la barra superior de navegación para consultar las distintas secciones de nuestra compañía
                        </p>
                    </div>
                </Jumbotron>
                <Carousel>
                    <Carousel.Item>
                        <img src='https://s6.eestatic.com/2018/10/10/ciencia/investigacion/Hospitales-Bacterias-Bano-Investigacion_344478113_100893020_1024x576.jpg'/>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img src='https://s5.eestatic.com/2018/11/19/ciencia/salud/Branded_Content-Marcas_N-Quironsalud-Sanidad-Hospitales-Salud_354475911_106542643_1024x576.jpg'/>
                    </Carousel.Item>
                </Carousel>
            </>
        );
    }
}