import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlightsRoutingModule } from './flights-routing.module';
import { FlightListComponent } from './flight-list/flight-list.component';
import { FlightComponent } from './flight/flight.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [FlightListComponent, FlightComponent],
    imports: [CommonModule, FlightsRoutingModule, SharedModule],
})
export class FlightsModule {}
