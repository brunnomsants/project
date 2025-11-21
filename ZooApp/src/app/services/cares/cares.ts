import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'; 
import { API_URL } from "../../app.config";

export interface Care {
  id: number;
  animalId: string | null;
  name: string | null;
  description: string | null;
  frequency: string | null;
}

@Injectable({
  providedIn: 'root',
})
export class CaresService {
  private apiUrl = `${API_URL}/cares`;
  constructor(private http: HttpClient) {}
  getCares(): Observable<Care[]> {
    return this.http.get<Care[]>(this.apiUrl);
  }

  getCare(id: number): Observable<Care> {
    return this.http.get<Care>(`${this.apiUrl}/${id}`);
  }
  createCare(care: Care): Observable<Care> {
    return this.http.post<Care>(this.apiUrl, care);
  }
  updateCare(id: number, care: Care): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, care);
  }
  deleteCare(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
