import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { HttpClient } from '@angular/common/http';
import { loadAirportsAction, loadAirportsSuccessAction } from './airports.actions';
import { catchError, EMPTY, map, switchMap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Airport } from './models/airport';

@Injectable()
export class AirportsEffects {
    constructor(private _actions$: Actions, private _http: HttpClient) {}

    public loadAirports$ = createEffect(() =>
        this._actions$.pipe(
            ofType(loadAirportsAction.type),
            switchMap(() =>
                this._http.get(`${environment.apiUrl}/api/airports`).pipe(
                    map(airports => loadAirportsSuccessAction({ airports: airports as Airport[] })),
                    catchError(() => EMPTY),
                ),
            ),
        ),
    );
}
