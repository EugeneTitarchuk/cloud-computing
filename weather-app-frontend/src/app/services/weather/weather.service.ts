import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, delay, map } from 'rxjs';
import { OPEN_WEATHER_KEY, BACKEND_URL } from 'src/app/models/api-keys';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  constructor(private http: HttpClient) { }

  /**
   * [GET] Weather for city by name
   *
   */
  getWeatherForCity(city: string): Observable<any> {
    const path = `${BACKEND_URL}/weatherforecast?city=${city}`;

    return this.http.get<any>(path).pipe(
      map((data) => ({
        ...data,
        image: `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`
      })),
      delay(500)
    );
  }


  /**
   * [GET] Weather for city by current geolocation
   *
   * latitude,
   * longitude
   */
  getWeatherForLatLon(lat: number, lon: number): Observable<any> {
    const path = `${BACKEND_URL}/weatherforecast?lat=${lat}&lon=${lon}`;

    return this.http.get<any>(path).pipe(
      map((data) => ({
        ...data,
        image: `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`
      })),
      delay(500)
    );
  }
}
