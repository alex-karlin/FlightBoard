import { Airport } from './models/airport';
import { Action, createReducer, on } from '@ngrx/store';
import { loadAirportsAction, loadAirportsSuccessAction } from './airports.actions';

export interface AirportsState {
    loading: boolean;
    airports: Airport[] | null;
}

const initialState: AirportsState = {
    loading: false,
    airports: null,
};

const reducer = createReducer(
    initialState,
    on(loadAirportsAction, state => ({ ...state, loading: true })),
    on(loadAirportsSuccessAction, (state, { airports }) => ({
        ...state,
        loading: false,
        airports,
    })),
);

export function airportsReducer(state: AirportsState | undefined, action: Action) {
    return reducer(state, action);
}
