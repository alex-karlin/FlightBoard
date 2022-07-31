import { FlightStatus } from './flight-status';

export interface Flight {
    flightId: number;
    flightNumber: string;
    airlineName: string;
    destination: string;
    scheduledDepartureTime: Date;
    estimatedDepartureTime: Date;
    actualDepartureTime: Date;
    status: FlightStatus;
    departureGate: string;
}
