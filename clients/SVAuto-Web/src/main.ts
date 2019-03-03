import 'hammerjs';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { SimpleStoreModule } from './app/modules/simple-store/simple-store.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

//platformBrowserDynamic().bootstrapModule(AppModule)
//  .catch(err => console.error(err));

platformBrowserDynamic().bootstrapModule(SimpleStoreModule)
    .catch(err => console.error(err));
