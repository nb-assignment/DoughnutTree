import { TestBed, async, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AppConfigService } from '../../_services/appconfig.service';

describe('AppConfigService', () => {
  let appConfigService: AppConfigService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
      ],
      providers: [
        AppConfigService
      ],
    });

    appConfigService = TestBed.get(AppConfigService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it(`should fetch environment as an observable`, async(inject([HttpTestingController, AppConfigService],
    (httpClient: HttpTestingController, appConfigService: AppConfigService) => {
      const mockAppSettings = {
        appInsightsInstrumentationKey: 'test-key'
      };

      appConfigService.loadEnvironment().subscribe(
        appSettings => {
          expect(appSettings.appInsightsInstrumentationKey).toEqual('test-key');
        }
      );

      let req = httpMock.expectOne('/environment');
      
      req.flush(mockAppSettings);
      httpMock.verify();
    })));

  it(`request method should be get`, async(inject([HttpTestingController, AppConfigService],
    (httpClient: HttpTestingController, appConfigService: AppConfigService) => {      
      appConfigService.loadEnvironment().subscribe();

      let req = httpMock.expectOne('/environment');
      expect(req.request.method).toBe("GET");

      httpMock.verify();
    })));
});
