import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BACKEND_URL } from 'src/app/models/api-keys';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  constructor(private http: HttpClient) { }

  /**
   * [GET] Cities
   *
   */
  findCities(namePrefix: string) {
    const path = `${BACKEND_URL}/geolocation`;

    const options = {
      method: 'GET' as const,
      params: {
        city: namePrefix,
      }
    }

    return this.http.get<any>(path, options);
  }
}
