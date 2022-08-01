import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirportComponent } from './airport.component';
import { Airport } from '../state';
import { DataBuilder } from '../../shared';
import { By } from '@angular/platform-browser';

describe('AirportComponent', () => {
    let component: AirportComponent;
    let fixture: ComponentFixture<AirportComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [AirportComponent],
        }).compileComponents();

        fixture = TestBed.createComponent(AirportComponent);
        component = fixture.componentInstance;
        component.airport = new DataBuilder<Airport>()
            .assign({
                airportId: 1,
                name: 'Christchurch Airport',
            })
            .build();
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should display airport name', () => {
        const nameEl = fixture.debugElement.query(By.css('.data-airport-name'));
        expect(nameEl.nativeElement.innerText).toBe(component.airport.name);
    });
});
