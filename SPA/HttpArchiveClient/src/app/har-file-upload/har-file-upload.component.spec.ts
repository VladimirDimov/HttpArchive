import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HarFileUploadComponent } from './har-file-upload.component';

describe('HarFileUploadComponent', () => {
  let component: HarFileUploadComponent;
  let fixture: ComponentFixture<HarFileUploadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HarFileUploadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HarFileUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
