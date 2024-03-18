# Introduction

This application was created for the coding challenge described in ``doc\Code Assessment.pdf``.

## Architecture

The application is composed of WPF frontend and a REST-API as the backend. The FakeLocationProvider is created to produce locations. 

The data is stored in a temporal table in sql server. With this approach the historical data could be played back.

An grapfical overview is found in ``doc\Architecture.drawio``.

## Data 

### Producer

The FakeLocationProvider produces and sends 140B per soldier position. Example:

```json
{
  "id": 99999,
  "type": 1,
  "location": {
    "latitude": 49.94319,
    "longitude": 7.44446
  },
  "createdAt": "2024-03-18T09:41:59.893Z",
  "trainingId": 12345
}
```
With 600 soldiers, that makes is around 82kB (per iteration).

### Consumer

The WPF frontend polls the backend 2x per second. So for 600 soldiers, 164kB are fetched per second and client. 
The client may be started multiple times.

