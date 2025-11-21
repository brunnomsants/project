import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CaresService, Care } from '../../services/cares/cares';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cares',
  imports: [],
  templateUrl: './cares.html',
  styleUrl: './cares.css',
})
export class CaresComponent implements OnInit {
  cares: Care[] = [];
  animalId: number | null = null;


  constructor(private caresService: CaresService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('animalId');
      this.animalId = id ? +id : null;
    });
/*
  loadCares() {
    this.caresService.getCares().subscribe((data) => {
      this.cares = data;
    });
  }
  save(): void {
    if (this.isEditing) {
      this.caresService.updateCare(this.selectedCare.id, this.selectedCare).subscribe({
        next: () => {
          this.loadCares();
          this.cancel();
        },
        error: (error) => console.error('Erro ao atualizar cuidado', error)
      });
    } else {
      this.caresService.createCare(this.selectedCare).subscribe({
        next: () => {
          this.loadCares();
          this.cancel();
        },
        error: (error) => console.error('Erro ao criar cuidado', error)
      });
    }
      */
  }
    
}
