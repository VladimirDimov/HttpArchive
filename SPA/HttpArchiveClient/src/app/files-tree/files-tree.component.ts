import { Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable, Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { HarFileService } from '../services/har-file-upload.service';
import { FolderModel } from '../shared/models/tree.models';

@Component({
  selector: 'app-files-tree',
  templateUrl: './files-tree.component.html',
  styleUrls: ['./files-tree.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class FilesTreeComponent implements OnInit, OnDestroy {
  private _onDestroy = new Subject<void>();

  constructor(private service: HarFileService, private spinner: NgxSpinnerService) { }

  public data: FolderModel = new FolderModel();

  @Input() $data: Observable<FolderModel>;
  @Input() $refreshOn: Observable<FolderModel>;
  @Input() title: string;

  ngOnInit() {
    this.fetchData();
    this.$refreshOn
      .pipe(takeUntil(this._onDestroy))
      .subscribe(_ => this.fetchData());
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }

  fetchData() {
    this.spinner.show('Loading file ...');

    this.$data
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .pipe(takeUntil(this._onDestroy))
      .subscribe((data: FolderModel) => {
        this.data = data;
        console.log(data);
      });
  }
}
