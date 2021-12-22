import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HarFileDetailsComponent } from './har-file-details.component';

describe('HarFileDetailsComponent', () => {
  let component: HarFileDetailsComponent;
  let fixture: ComponentFixture<HarFileDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HarFileDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HarFileDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
