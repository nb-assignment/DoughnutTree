import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DoughnutTreeComponent } from './doughnut-tree.component';

describe('DoughnutTreeComponent', () => {
  let component: DoughnutTreeComponent;
  let fixture: ComponentFixture<DoughnutTreeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DoughnutTreeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DoughnutTreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
