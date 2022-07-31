import { FlightsState } from '../flights/state';

export interface RootState {
    airports: FlightsState;
    flights: FlightsState;
}
