import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { HarFileService } from '../services/har-file-upload.service';
import { HarFileModel } from '../shared/models/har-file.model';

@Component({
  selector: 'app-har-file-details',
  templateUrl: './har-file-details.component.html',
  styleUrls: ['./har-file-details.component.scss']
})
export class HarFileDetailsComponent implements OnInit, OnDestroy {
  private _onDestroy = new Subject<void>();
  constructor(private service: HarFileService,
    private fb: FormBuilder,
    private spinner: NgxSpinnerService) { }

  public data: HarFileModel;
  public fileShareForm: FormGroup;

  ngOnInit() {
    this.service.onFileDetailsLoaded.subscribe((fileDetails: HarFileModel) => {
      this.data = fileDetails;

      this.fileShareForm = this.fb.group({
        id: this.fb.control(fileDetails.id),
        emails: this.fb.control(fileDetails.sharedWith.join(', '))
      });
      console.log(fileDetails);
    });
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }

  public share(): void {
    const requestData = this.fileShareForm.getRawValue();
    console.log(requestData);
    this.spinner.show('Sharing file...')
    this.service.share(requestData)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .pipe(takeUntil(this._onDestroy))
      .subscribe(_ => {
        this.service.emitFileShared();
      });
  }

}
