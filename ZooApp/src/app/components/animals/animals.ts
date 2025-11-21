import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AnimalService, Animal } from '../../services/animals/animals';
import { Router } from '@angular/router';


@Component({
  selector: 'app-animals',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './animals.html',
  styleUrls: ['../../app.css'],
})


export class AnimalsComponent implements OnInit {
  animals: Animal[] = [];
  selectedAnimal: Animal = this.newAnimal();
  isEditing = false;
  
  constructor(private animalService: AnimalService, private router: Router) { }

  ngOnInit(): void {
    this.loadAnimals();
  }

  loadAnimals(): void {
    this.animalService.getAnimals().subscribe({
      next: (data) => this.animals = data,
      error: (error) => console.error('Erro ao carregar animais', error)
    });
  }

  save(): void {
    if (this.isEditing) {
      this.animalService.updateAnimal(this.selectedAnimal.id, this.selectedAnimal).subscribe({
        next: () => {
          this.loadAnimals();
          this.cancel();
        },
        error: (error) => console.error('Erro ao atualizar animal', error)
      });
    } else {
      this.animalService.createAnimal(this.selectedAnimal).subscribe({
        next: () => {
          this.loadAnimals();
          this.cancel();
        },
        error: (error) => console.error('Erro ao criar animal', error)
      });
    }
  }

  edit(animal: Animal): void {
    this.selectedAnimal = { ...animal };
    this.isEditing = true;
  }

  delete(id: number): void {
    if (confirm('Tem certeza que deseja excluir este animal?')) {
      this.animalService.deleteAnimal(id).subscribe({
        next: () => this.loadAnimals(),
        error: (error) => console.error('Erro ao deletar animal', error)
      });
    }
  }

  cancel(): void {
    this.selectedAnimal = this.newAnimal();
    this.isEditing = false;
  }

  trackById(index: number, item: Animal) {
    return item.id;
  }

  goToCares(animalId: number) {
    this.router.navigate(['/cares', animalId]);
  }

  private newAnimal(): Animal {
    return {
      id: 0,
      name: '',
      description: '',
      birthday: null,
      species: '',
      habitat: '',
      countryOfOrigin: ''
    };
  }
}
