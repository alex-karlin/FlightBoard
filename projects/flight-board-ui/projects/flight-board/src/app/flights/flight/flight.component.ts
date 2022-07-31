import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { Flight } from '../state';

@Component({
    selector: 'app-flight',
    templateUrl: './flight.component.html',
    styleUrls: ['./flight.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FlightComponent {
    @Input()
    public flight: Flight = null!;

    public selectFlight() {
        alert('Flight selection is not implemented yet.');
    }
}
