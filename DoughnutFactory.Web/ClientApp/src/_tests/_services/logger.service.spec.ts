import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { LoggerService } from 'src/app/_services/logger.service';
import { AppConfigService } from 'src/app/_services/appconfig.service';
import { RouterTestingModule } from '@angular/router/testing';

describe("Logger", () => {

  let loggerServiceSpy: any;
  let instrumentationKey: string = "test";
  //Initialise Mocks
  beforeEach(() => {
    TestBed.configureTestingModule(
      { imports: [HttpClientTestingModule, RouterTestingModule], providers: [LoggerService, AppConfigService] });
  });

  it('Should initialise service', inject([LoggerService], (service: LoggerService) => {
    expect(service).toBeTruthy();
  }));

  it('Should app insight key be set', inject([LoggerService], (service: LoggerService) => {
    expect(service).toBeTruthy();
    service.loadLogger(instrumentationKey)
    expect(service.appInsights.config.instrumentationKey).toEqual("test");
  }));

  it('Assert clearUserId "clears the user id" ', inject([LoggerService], (service: LoggerService) => {
    expect(service).toBeTruthy();
    service.loadLogger(instrumentationKey);
    service.clearUserId();
    expect(service.appInsights.context.user.authenticatedId).toBeNull();
  }));

  it('Assert setUserId "sets the user"', inject([LoggerService], (service: LoggerService) => {
    expect(service).toBeTruthy();
    service.loadLogger(instrumentationKey);
    service.setUserId("123456");
    expect(service.appInsights.context.user).toBeDefined();
  }));

  it('Assert setUserId "sets the userid to 123456"', inject([LoggerService], (service: LoggerService) => {
    expect(service).toBeTruthy();
    service.loadLogger(instrumentationKey);
    service.setUserId("123456");
    expect(service.appInsights.context.user.authenticatedId).toEqual("123456");
  }));

  it('Should log error and spy on track exception', inject([LoggerService], (service: LoggerService) => {
    var error: Error = new Error();
    error.message = "error message";
    error.name = "logging service";
    error.stack = "stack trace";
    service.loadLogger(instrumentationKey);
    loggerServiceSpy = spyOn(service.appInsights, 'trackException').and.callThrough();
    service.logError(error)
    expect(loggerServiceSpy).toHaveBeenCalled();
  }));

  it('Should log page view and spy on trackPageView', inject([LoggerService], (service: LoggerService) => {
    service.loadLogger(instrumentationKey);
    loggerServiceSpy = spyOn(service.appInsights, "trackPageView").and.callThrough();
    service.logPageView("Upload", "/upload");
    expect(loggerServiceSpy).toHaveBeenCalled();
  }));

  it('Should log customEvent with object and spy on trackEvent', inject([LoggerService], (service: LoggerService) => {
    service.loadLogger(instrumentationKey);
    let properties: any = new Object("12345");
    loggerServiceSpy = spyOn(service.appInsights, "trackEvent").and.callThrough();
    service.logCustomEvent("Upload", properties);
    expect(loggerServiceSpy).toHaveBeenCalled();
  }));

  it('Should log customEvent without object and spy on trackEvent ', inject([LoggerService], (service: LoggerService) => {
    service.loadLogger(instrumentationKey);
    let properties: any = null;
    loggerServiceSpy = spyOn(service.appInsights, "trackEvent").and.callThrough();
    service.logCustomEvent("Upload", properties);
    expect(loggerServiceSpy).toHaveBeenCalled();
  }));

});

