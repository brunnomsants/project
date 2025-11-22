import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs'; 
import { API_URL } from "../../app.config";

export interface Care {
  id: number;
  animalId: number | null;
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

  getCaresByAnimal(animalId: number): Observable<Care[]> {
    return this.http.get<Care[]>(`${this.apiUrl}/Cares/ByAnimal/${animalId}`).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(() => error);
      })
    );
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
