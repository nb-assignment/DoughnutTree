import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { shareReplay } from 'rxjs/operators';
import { AppSettings } from '../_interfaces/appsettings.service'

@Injectable()
export class AppConfigService {

  private configuration$: Observable<AppSettings>;

  constructor(private http: HttpClient) {
  }

  // Using shareReplay, the actual HTTP call will only be called once
  // every other call will return a cached version of the response,
  // saving precious resources
  public loadEnvironment(): Observable<AppSettings> {
    if (!this.configuration$) {
      this.configuration$ = this.http.get<AppSettings>(`/environment`).pipe(
        shareReplay(1)
      );
    }

    return this.configuration$;
  }

}
