import { isDevMode } from '@angular/core';

export class BaseService {

  protected apiUrl() {
    if (isDevMode()) {
      return 'http://apipacientes.azurewebsites.net/api';
    }
    else {
      return 'http://apipacientes.azurewebsites.net/api';
    }
  }
}
