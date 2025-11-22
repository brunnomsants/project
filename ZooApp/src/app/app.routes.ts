import { Routes } from '@angular/router';
import { AnimalsComponent } from './components/animals/animals';
import { CaresComponent } from './components/cares/cares';
import { NotFoundComponent } from './components/not-found/not-found';

export const routes: Routes = [
  { path: '', redirectTo: 'animals', pathMatch: 'full' },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'animals', component: AnimalsComponent },
  { path: 'cares/:animalId', component: CaresComponent }
];
