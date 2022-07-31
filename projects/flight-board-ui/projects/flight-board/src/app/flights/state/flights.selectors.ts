import { createFeatureSelector, createSelector } from '@ngrx/store';
import { FlightsState } from './flights.reducer';

export const selectFlightsState = createFeatureSelector<FlightsState>('flights');

export const selectFlightsLoading = createSelector(selectFlightsState, state => state.loading);

export const selectFlights = createSelector(selectFlightsState, state => state.flights);
