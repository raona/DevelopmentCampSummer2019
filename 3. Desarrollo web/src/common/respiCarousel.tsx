import React from "react";
import Carousel from "react-bootstrap/Carousel";
import carouselItemImage from "../entities/carouselItemImage";

export interface CarouselItemProps {
    carouselItemImages: carouselItemImage[];
}

export default class RespiCarousel extends React.Component<CarouselItemProps, {}> {
    public render() {
        let { carouselItemImages } = this.props;

        return (
            <Carousel>
                {
                    carouselItemImages.map(item => {
                        return <Carousel.Item>
                            <img className={item.className} src={item.src} alt={item.alt} />
                        </Carousel.Item>
                    })
                }
            </Carousel>
        );
    }
}