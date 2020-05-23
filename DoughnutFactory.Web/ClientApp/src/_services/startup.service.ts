import { Injectable } from '@angular/core';
import { AppConfigService } from './appconfig.service';
import { AppSettings } from '../_interfaces/appsettings.service';
import { LoggerService } from './logger.service';

@Injectable({ providedIn: 'root' })
export class StartUpService {
  constructor(private configService: AppConfigService, private logger: LoggerService) { }

  public  initializeAppSettings(): Promise<AppSettings> {
    return this.configService.loadEnvironment().toPromise();
  }

  public async initializeApp()
  {
    let appSettings = await this.initializeAppSettings();
    this.logger.loadLogger(appSettings.appInsightsInstrumentationKey);
  }
}
