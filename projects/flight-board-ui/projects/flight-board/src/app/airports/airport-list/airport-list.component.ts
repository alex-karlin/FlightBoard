import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { RootState } from '../../state';
import { Airport, loadAirportsAction, selectAirports, selectAirportsLoading } from '../state';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-airport.ts-list',
    templateUrl: './airport-list.component.html',
    styleUrls: ['./airport-list.component.scss'],
})
export class AirportListComponent implements OnInit {
    public loading$: Observable<boolean> = null!;
    public airports$: Observable<Airport[] | null> = null!;

    constructor(private _store: Store<RootState>) {
        this._store.dispatch(loadAirportsAction());
    }

    public ngOnInit() {
        this.loading$ = this._store.pipe(select(selectAirportsLoading));
        this.airports$ = this._store.pipe(select(selectAirports));
    }
}
