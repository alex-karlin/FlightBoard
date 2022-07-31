import { Flight } from './models/flight';
import { Action, createReducer, on } from '@ngrx/store';
import { loadFlightsAction, loadFlightsSuccessAction } from './flights.actions';

export interface FlightsState {
    loading: boolean;
    flights: Flight[] | null;
}

const initialState: FlightsState = {
    loading: false,
    flights: null,
};

const reducer = createReducer(
    initialState,
    on(loadFlightsAction, state => ({ ...state, loading: true })),
    on(loadFlightsSuccessAction, (state, { flights }) => ({ ...state, loading: false, flights })),
);

export function flightsReducer(state: FlightsState | undefined, action: Action) {
    return reducer(state, action);
}
