import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-found',
  imports: [],
  templateUrl: './not-found.html',
  styleUrl: '../../app.css',
})
export class NotFoundComponent {
  message = history.state.message ?? "Recurso não encontrado.";
  constructor(private router: Router) {}

  back(): void {
    this.router.navigate(['/..']);
  }
}
