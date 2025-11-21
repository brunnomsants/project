import { Component } from '@angular/core';
import { AnimalsComponent } from './components/animals/animals';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [AnimalsComponent],
  template: '<app-animals></app-animals>',
  styles: []
})
export class App {
  title = 'ZooApp';
}
