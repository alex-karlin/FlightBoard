import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AirportsModule } from './airports/airports.module';
import { FlightsModule } from './flights/flights.module';
import { StoreModule } from '@ngrx/store';
import { AirportsEffects, airportsReducer } from './airports/state';
import { flightsReducer } from './flights/state';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { FlightsEffects } from './flights/state/flights.effects';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        HttpClientModule,
        StoreModule.forRoot({
            airports: airportsReducer,
            flights: flightsReducer,
        }),
        StoreRouterConnectingModule.forRoot(),
        StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production }),
        EffectsModule.forRoot([AirportsEffects, FlightsEffects]),
        AirportsModule,
        FlightsModule,
        AppRoutingModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
