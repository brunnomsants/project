import { ApplicationConfig } from '@angular/core';
import { provideHttpClient, withFetch } from '@angular/common/http';


export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withFetch())
  ]
};

export const API_URL = 'http://localhost:5130/api';
