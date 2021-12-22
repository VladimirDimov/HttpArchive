import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilesTreeFolderComponent } from './files-tree-folder.component';

describe('FilesTreeFolderComponent', () => {
  let component: FilesTreeFolderComponent;
  let fixture: ComponentFixture<FilesTreeFolderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilesTreeFolderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilesTreeFolderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
