import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FlightsRoutingModule } from './flights-routing.module';
import { FlightListComponent } from './flight-list/flight-list.component';
import { FlightComponent } from './flight/flight.component';

@NgModule({
    declarations: [FlightListComponent, FlightComponent],
    imports: [CommonModule, FlightsRoutingModule],
})
export class FlightsModule {}
