import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { HttpClient } from '@angular/common/http';
import { loadFlightsAction, loadFlightsSuccessAction } from './flights.actions';
import { environment } from '../../../environments/environment';
import { Flight } from './models/flight';
import { catchError, EMPTY, map, switchMap } from 'rxjs';

@Injectable()
export class FlightsEffects {
    constructor(private _actions$: Actions, private _http: HttpClient) {}

    public loadFlights$ = createEffect(() =>
        this._actions$.pipe(
            ofType(loadFlightsAction.type),
            switchMap(({ airportId }) =>
                this._http.get(`${environment.apiUrl}/api/airports/${airportId}/flights`).pipe(
                    map(flights => loadFlightsSuccessAction({ flights: flights as Flight[] })),
                    catchError(() => EMPTY),
                ),
            ),
        ),
    );
}
