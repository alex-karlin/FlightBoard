import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RootState } from '../../state';
import { select, Store } from '@ngrx/store';
import { Flight, loadFlightsAction, selectFlights, selectFlightsLoading } from '../state';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-flight-list',
    templateUrl: './flight-list.component.html',
    styleUrls: ['./flight-list.component.scss'],
})
export class FlightListComponent implements OnInit {
    public loading$: Observable<boolean> = null!;
    public flights$: Observable<Flight[] | null> = null!;

    constructor(private _store: Store<RootState>, private _route: ActivatedRoute) {}

    public ngOnInit() {
        const airportIdResult = this.parseAirportId(this._route.snapshot.paramMap.get('airportId'));
        if (airportIdResult.success) {
            this._store.dispatch(loadFlightsAction({ airportId: airportIdResult.airportId }));
        }

        this.loading$ = this._store.pipe(select(selectFlightsLoading));
        this.flights$ = this._store.pipe(select(selectFlights));
    }

    private parseAirportId(airportIdParam: string | null) {
        let success = false;
        let airportId = -1;
        if (Boolean(airportIdParam) && (airportId = parseInt(airportIdParam!)) !== NaN) {
            success = true;
        }
        return { success, airportId };
    }
}
