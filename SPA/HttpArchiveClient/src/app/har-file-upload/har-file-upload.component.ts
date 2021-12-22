import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { HarFileService } from '../services/har-file-upload.service';

@Component({
  selector: 'app-har-file-upload',
  templateUrl: './har-file-upload.component.html',
  styleUrls: ['./har-file-upload.component.sass']
})
export class HarFileUploadComponent implements OnInit, OnDestroy {
  private _onDestroy = new Subject<void>();

  constructor(private fb: FormBuilder,
    private harFileService: HarFileService,
    private spinner: NgxSpinnerService) { }

  public fileUploadForm: FormGroup;

  ngOnInit() {
    this.fileUploadForm = this.fb.group({
      path: this.fb.control('', [Validators.maxLength(200)]),
      fileContent: this.fb.control(null, [Validators.required]),
      fileSource: this.fb.control(null, [Validators.required, this.validateFileSize]),
    });
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }

  public onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.fileUploadForm.patchValue({
        fileSource: file
      });
    }
  }

  public submit() {
    const formData = new FormData();
    formData.append('fileContent', this.fileUploadForm.get('fileSource').value);
    formData.append('filePath', this.fileUploadForm.get('path').value);
    console.log(formData);

    this.spinner.show();
    this.harFileService.upload(formData)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .pipe(takeUntil(this._onDestroy))
      .subscribe(_response => {
        this.spinner.hide();
        this.harFileService.emitFileUploaded();
      });
  }

  validateFileSize(control: AbstractControl) {
    if (!control || !control.value) return null;
    const fileSize = control.value.size ? control.value.size / 1024 / 1024 : 0;
    if (fileSize > 10) {
      return { fileSizeExceedLimitation: true };
    }

    return null;
  }
}
