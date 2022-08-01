import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirportListComponent } from './airport-list.component';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { Airport, loadAirportsAction, selectAirports, selectAirportsLoading } from '../state';
import { By } from '@angular/platform-browser';
import { DataBuilder } from "../../shared";

describe('AirportListComponent', () => {
    let component: AirportListComponent;
    let fixture: ComponentFixture<AirportListComponent>;
    let store: MockStore;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            providers: [
                provideMockStore({
                    selectors: [
                        { selector: selectAirportsLoading, value: false },
                        { selector: selectAirports, value: [] },
                    ],
                }),
            ],
            declarations: [AirportListComponent],
        }).compileComponents();

        store = TestBed.inject(MockStore);
        fixture = TestBed.createComponent(AirportListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    describe('Method: ngOnInit', () => {
        it('should dispatch load airports action', () => {
            spyOn(store, 'dispatch');

            component.ngOnInit();

            expect(store.dispatch).toHaveBeenCalledWith(loadAirportsAction());
        });

        it('should display progress bar when loading', () => {
            store.overrideSelector(selectAirportsLoading, true);

            component.ngOnInit();
            fixture.detectChanges();

            expect(fixture.debugElement.query(By.css('app-progress-bar'))).toBeTruthy();
        });

        it('should display airports when loaded', () => {
            const airports = new DataBuilder<Airport>().buildList(2);
            store.overrideSelector(selectAirportsLoading, false);
            store.overrideSelector(selectAirports, airports);

            component.ngOnInit();
            fixture.detectChanges();

            expect(fixture.debugElement.queryAll(By.css('app-airport')).length).toBe(airports.length);
        });
    });
});
