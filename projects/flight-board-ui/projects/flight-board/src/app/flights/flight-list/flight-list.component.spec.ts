import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightListComponent } from './flight-list.component';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { loadFlightsAction, selectFlights, selectFlightsLoading } from '../state';
import { Mock, provideMock } from '../../shared';
import { ActivatedRoute } from '@angular/router';

describe('FlightListComponent', () => {
    let component: FlightListComponent;
    let fixture: ComponentFixture<FlightListComponent>;
    let store: MockStore;
    let activatedRoute: Mock<ActivatedRoute>;
    let airportIdParam: string | null = '';

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            providers: [
                provideMockStore({
                    selectors: [
                        { selector: selectFlightsLoading, value: false },
                        { selector: selectFlights, value: [] },
                    ],
                }),
                provideMock(ActivatedRoute),
            ],
            declarations: [FlightListComponent],
        }).compileComponents();

        fixture = TestBed.createComponent(FlightListComponent);
        store = TestBed.inject(MockStore);
        activatedRoute = TestBed.inject(ActivatedRoute) as Mock<ActivatedRoute>;
        activatedRoute.snapshot = {
            paramMap: {
                get: () => airportIdParam,
            },
        } as any;
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    describe('Method: ngOnInit', () => {
        it('should load flights if airport id is valid', () => {
            const airportId = 123;
            airportIdParam = airportId.toString();
            spyOn(store, 'dispatch');

            component.ngOnInit();

            expect(store.dispatch).toHaveBeenCalledWith(loadFlightsAction({ airportId }));
        });

        [
            { name: 'null', value: null},
            { name: 'empty string', value: ''},
            { name: 'not a number', value: 'banana'},
        ].forEach(({ name, value}) =>
            it(`should not load flights if airport id is ${name}`, () => {
                airportIdParam = value;
                spyOn(store, 'dispatch');

                component.ngOnInit();

                expect(store.dispatch).not.toHaveBeenCalled();
            }))
        ;
    });
});
