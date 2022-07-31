import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Airport } from "../state";

@Component({
    selector: 'app-airport',
    templateUrl: './airport.component.html',
    styleUrls: ['./airport.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AirportComponent {
    @Input()
    public airport: Airport = null!;
}
