import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(
    public translate: TranslateService
  ) {
    // add the supported languages
    translate.addLangs(['en', 'nl']);
    // set the default language
    translate.setDefaultLang('en');
    // get the browsers language
    const browserLang = translate.getBrowserLang();
    // set the app language
    translate.use(browserLang.match(/en|nl/) ? browserLang : 'en');
  }
}
