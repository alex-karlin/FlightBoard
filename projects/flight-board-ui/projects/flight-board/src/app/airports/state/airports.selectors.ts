import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AirportsState } from './airports.reducer';

export const selectAirportsState = createFeatureSelector<AirportsState>('airports');

export const selectAirportsLoading = createSelector(selectAirportsState, state => state.loading);

export const selectAirports = createSelector(selectAirportsState, state => state.airports);
