import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CaresService, Care } from '../../services/cares/cares';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { AnimalService } from '../../services/animals/animals';

@Component({
  selector: 'app-cares',
  imports: [FormsModule, CommonModule],
  templateUrl: './cares.html',
  styleUrl: '../../app.css',
})
export class CaresComponent implements OnInit {
  cares: Care[] = [];
  animalId: number | null = null;
  selectedCare: Care = this.newCare();
  isEditing = false;
  animalName: string = '';

  constructor(private caresService: CaresService, private route: ActivatedRoute, private router: Router, private animalService: AnimalService) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('animalId');
      this.animalId = id ? +id : null;
      
      this.loadCares();
      if(this.animalId !== null) {
        this.animalService.getAnimal(this.animalId).subscribe({
          next: (animal) => {
            this.animalName = animal.name || '';  
          },
          error: (error) => {console.error('Erro ao carregar animal', error);
            this.router.navigate(['/not-found'], {
              state: { message: "Animal não encontrado." }
            });
          }
            
        });
      }
    })
  };
  
 loadCares(): void {
    if (this.animalId !== null) {
      this.caresService.getCaresByAnimal(this.animalId).subscribe({
        next: (data) => this.cares = data,
        error: (err) => {
          console.error(err);
          if (err.status === 404) {    
            this.router.navigate(['/not-found'], {
              state: { message: "Animal não encontrado." }
            });
          }
        }
      });
    }
  }



  save(): void {
    if (this.animalId === null) return;
  
    this.selectedCare.animalId = this.animalId;

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
  }

  edit(care: Care): void {
    this.selectedCare = { ...care };
    this.isEditing = true;
  }

  delete(id: number): void {
    this.caresService.deleteCare(id).subscribe({
      next: () => this.loadCares(),
      error: (error) => console.error('Erro ao deletar cuidado', error)
    });
  }

  cancel(): void {
    this.selectedCare = this.newCare();
    this.isEditing = false;
  }

  trackById(index: number, item: Care) {
    return item.id;
  }

  goToAnimals(): void {
    this.router.navigate(['/..']);
  }

  private newCare(): Care {
      return {
        id: 0,
        animalId: this.animalId,
        name: '',
        description: '',
        frequency: '',
      
      };
    }
    
}
