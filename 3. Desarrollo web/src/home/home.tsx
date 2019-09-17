import React from 'react';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Image from 'react-bootstrap/Image';
import carouselItemImages from '../constants/carouselItemImages';
import RespiCarousel from '../common/respiCarousel';

export default class Home extends React.Component {
    public render() {
        return (
            <>
                <Jumbotron style={{ marginBottom: '0px' }}>
                    <Image style={{ display: 'inline-block' }} rounded src='https://memenginy.enginyeriauab.cat/wp-content/uploads/2019/02/LogoRaona-1.png' height="170px" />
                    <div style={{ display: 'inline-block', verticalAlign: 'middle' }}>
                        <h1>¡Bienvenidos a Respitron!</h1>
                        <p>
                            Usad la barra superior de navegación para consultar las distintas secciones de nuestra compañía
                        </p>
                    </div>
                </Jumbotron>
                {
                    carouselItemImages.length > 1 ?
                        <RespiCarousel carouselItemImages={carouselItemImages} /> :
                        <img alt={carouselItemImages[0].alt} src={carouselItemImages[0].src} className={carouselItemImages[0].className} />
                }
            </>
        );
    }
}