import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_URL } from "../../app.config";

export interface Animal {
  id: number;
  name: string | null;
  description: string | null;
  birthday: string | null;
  species: string | null;
  habitat: string | null;
  countryOfOrigin: string | null;
}

@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private apiUrl = (`${API_URL}/animals`);

  constructor(private http: HttpClient) { }

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.apiUrl);
  }

  getAnimal(id: number): Observable<Animal> {
    return this.http.get<Animal>(`${this.apiUrl}/${id}`);
  }

  createAnimal(animal: Animal): Observable<Animal> {
    return this.http.post<Animal>(this.apiUrl, animal);
  }

  updateAnimal(id: number, animal: Animal): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, animal);
  }

  deleteAnimal(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
