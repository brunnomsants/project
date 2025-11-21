import { Routes } from '@angular/router';
import { AnimalsComponent } from './components/animals/animals';
import { CaresComponent } from './components/cares/cares';

export const routes: Routes = [
  { path: '', redirectTo: 'animals', pathMatch: 'full' },

  { path: 'animals', component: AnimalsComponent },
  { path: 'cares/:animalId', component: CaresComponent }
];
