import { FlightStatus } from './flight-status';

export interface Flight {
    flightId: number;
    airlineName: string;
    description: string;
    scheduledDepartureTime: Date;
    estimatedDepartureTime: Date;
    actualDepartureTime: Date;
    status: FlightStatus;
    departureGate: string;
}
