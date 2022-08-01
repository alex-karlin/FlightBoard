import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AirportsRoutingModule } from './airports-routing.module';
import { AirportListComponent } from './airport-list/airport-list.component';
import { AirportComponent } from './airport/airport.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [AirportListComponent, AirportComponent],
    imports: [CommonModule, AirportsRoutingModule, SharedModule],
})
export class AirportsModule {}
