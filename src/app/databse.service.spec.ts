import { TestBed } from '@angular/core/testing';

import { DatabseService } from './databse.service';

describe('DatabseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DatabseService = TestBed.get(DatabseService);
    expect(service).toBeTruthy();
  });
});
