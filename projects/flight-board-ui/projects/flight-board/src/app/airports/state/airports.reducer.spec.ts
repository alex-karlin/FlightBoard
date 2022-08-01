import { loadAirportsAction, loadAirportsSuccessAction } from './airports.actions';
import { DataBuilder } from '../../shared';
import { airportsReducer, AirportsState } from './airports.reducer';
import { Airport } from "./models/airport";

describe('Airports Reducer', () => {
    describe(loadAirportsAction.type, () => {
        it('should set loading to true', () => {
            const state = new DataBuilder<AirportsState>()
                .assign({
                    loading: false,
                })
                .build();

            const newState = airportsReducer(state, loadAirportsAction());

            expect(newState.loading).toBe(true);
        });
    });

    describe(loadAirportsSuccessAction.type, () => {
        it('should set loading to false', () => {
            const state = new DataBuilder<AirportsState>()
                .assign({
                    loading: true,
                })
                .build();

            const newState = airportsReducer(state, loadAirportsSuccessAction({ airports: [] }));

            expect(newState.loading).toBe(false);
        });

        it('should add airports to the new state', () => {
            const state = new DataBuilder<AirportsState>()
                .assign({
                    loading: true,
                    airports: []
                })
                .build();
            const airports = new DataBuilder<Airport>().buildList(5);

            const newState = airportsReducer(state, loadAirportsSuccessAction({ airports }));

            expect(newState.airports).toEqual(airports);
        });
    });
});
