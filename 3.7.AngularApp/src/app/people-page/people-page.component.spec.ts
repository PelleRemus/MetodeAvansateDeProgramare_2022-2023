import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PeoplePageComponent } from './people-page.component';

describe('PeoplePageComponent', () => {
  let component: PeoplePageComponent;
  let fixture: ComponentFixture<PeoplePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PeoplePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PeoplePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
