import { createAction, props } from '@ngrx/store';
import { Airport } from './models/airport';

export interface LoadAirportsSuccessPayload {
    airports: Airport[];
}

export const loadAirportsAction = createAction('[Flights] Load Airports');

export const loadAirportsSuccessAction = createAction(
    '[Flights] Load Airports Success',
    props<LoadAirportsSuccessPayload>(),
);
