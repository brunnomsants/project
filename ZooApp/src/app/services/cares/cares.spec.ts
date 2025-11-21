import { TestBed } from '@angular/core/testing';

import { Cares } from './cares';

describe('Cares', () => {
  let service: Cares;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Cares);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
