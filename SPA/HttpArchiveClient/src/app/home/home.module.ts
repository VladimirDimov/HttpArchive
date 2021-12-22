import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { HomeRoutingModule } from './home-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FilesTreeComponent } from '../files-tree/files-tree.component';
import { HarFileUploadComponent } from '../har-file-upload/har-file-upload.component';
import { FilesTreeFolderComponent } from '../files-tree/files-tree-folder/files-tree-folder.component';
import { HarFileDetailsComponent } from '../har-file-details/har-file-details.component';

@NgModule({
  declarations: [
    IndexComponent,
    FilesTreeComponent,
    HarFileUploadComponent,
    FilesTreeFolderComponent,
    HarFileDetailsComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    HomeRoutingModule,
    ReactiveFormsModule,
  ]
})
export class HomeModule { }
