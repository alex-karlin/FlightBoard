import { loadAirportsAction, loadAirportsSuccessAction } from './airports.actions';
import { AirportsEffects } from './airports.effects';
import { EMPTY, Observable, of, throwError } from 'rxjs';
import { Action } from '@ngrx/store';
import { DataBuilder, Mock, provideMock } from '../../shared';
import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { environment } from '../../../environments/environment';
import { Airport } from './models/airport';
import { hot } from 'jasmine-marbles';

describe('Airport Effects', () => {
    let effects: AirportsEffects;
    let actions$: Observable<Action>;
    let http: Mock<HttpClient>;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                AirportsEffects,
                provideMock(HttpClient),
                provideMockActions(() => actions$),
            ],
        });
        effects = TestBed.inject(AirportsEffects);
        http = TestBed.inject(HttpClient) as Mock<HttpClient>;
    });

    describe(loadAirportsAction.type, () => {
        it('should return success action', () => {
            const airports = new DataBuilder<Airport>().buildList(3);
            http.get.withArgs(`${environment.apiUrl}/api/airports`).and.returnValue(of(airports));

            actions$ = hot('a', { a: loadAirportsAction() });

            expect(effects.loadAirports$).toBeObservable(
                hot('a', { a: loadAirportsSuccessAction({ airports }) }),
            );
        });

        it('should return empty observable on error', () => {
            const airports = new DataBuilder<Airport>().buildList(3);
            http.get
                .withArgs(`${environment.apiUrl}/api/airports`)
                .and.returnValue(throwError(() => new Error()));

            actions$ = hot('a', { a: loadAirportsAction() });

            expect(effects.loadAirports$).toBeObservable(hot(''));
        });
    });
});
