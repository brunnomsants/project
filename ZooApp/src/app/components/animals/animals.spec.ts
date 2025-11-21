import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalsComponent } from './animals';

describe('Animal', () => {
  let component: AnimalsComponent;
  let fixture: ComponentFixture<AnimalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnimalsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnimalsComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
