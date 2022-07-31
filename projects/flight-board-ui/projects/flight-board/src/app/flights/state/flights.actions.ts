import { createAction, props } from '@ngrx/store';
import { Flight } from './models/flight';

export interface LoadFlightsPayload {
    airportId: number;
}

export interface LoadFlightsSuccessPayload {
    flights: Flight[];
}

export const loadFlightsAction = createAction(
    '[Flights] Load Flights',
    props<LoadFlightsPayload>(),
);

export const loadFlightsSuccessAction = createAction(
    '[Flights] Load Flights Success',
    props<LoadFlightsSuccessPayload>(),
);
