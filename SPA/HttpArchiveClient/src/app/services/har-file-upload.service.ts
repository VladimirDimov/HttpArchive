import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from "../shared/base.service";
import { ConfigService } from '../shared/config.service';
import { AuthService } from '../core/authentication/auth.service';
import { HarFileModel } from '../shared/models/har-file.model';

@Injectable({
  providedIn: 'root'
})
export class HarFileService extends BaseService {

  private fileDetailsLoadedEvent: EventEmitter<HarFileModel> = new EventEmitter<HarFileModel>();
  private fileUploadedEvent: EventEmitter<any> = new EventEmitter<any>();
  private fileSharedEvent: EventEmitter<any> = new EventEmitter<any>();

  constructor(private http: HttpClient,
    private configService: ConfigService,
    private authService: AuthService) {
    super();
  }

  get onFileDetailsLoaded() {
    return this.fileDetailsLoadedEvent;
  }

  public emitFileDetailsLoaded(harFileModel: HarFileModel) {
    this.fileDetailsLoadedEvent.emit(harFileModel);
  }

  get onFileUploaded() {
    return this.fileUploadedEvent;
  }

  public emitFileUploaded() {
    this.fileUploadedEvent.emit();
  }

  get onFileShared() {
    return this.fileSharedEvent;
  }

  public emitFileShared() {
    this.fileSharedEvent.emit();
  }

  public upload(data: FormData) {
    return this.http
      .post(this.configService.resourceApiURI + '/HarFile/upload', data, {
        headers: new HttpHeaders({
          'Authorization': this.authService.authorizationHeaderValue
        })
      })
      .pipe(catchError(this.handleError));
  }

  public share(data: any) {
    return this.http
      .post(this.configService.resourceApiURI + '/HarFile/share', data, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': this.authService.authorizationHeaderValue
        })
      })
      .pipe(catchError(this.handleError));
  }

  public getUserFiles() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': this.authService.authorizationHeaderValue,
        'Accept': 'application/json',
      })
    };

    return this.http
      .get(this.configService.resourceApiURI + '/HarFile', httpOptions)
      .pipe(catchError(this.handleError));
  }

  public getSharedFiles() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': this.authService.authorizationHeaderValue,
        'Accept': 'application/json',
      })
    };

    return this.http
      .get(this.configService.resourceApiURI + '/HarFile/shared-with-me', httpOptions)
      .pipe(catchError(this.handleError));
  }

  public getHarFileById(fileId: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': this.authService.authorizationHeaderValue,
        'Accept': 'application/json',
      })
    };

    return this.http
      .get(this.configService.resourceApiURI + `/HarFile/${fileId}`, httpOptions)
      .pipe(catchError(this.handleError));
  }
}
