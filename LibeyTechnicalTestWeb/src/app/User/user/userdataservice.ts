import { Injectable } from '@angular/core';
import { LibeyUser }  from 'src/app/entities/libeyuser';


@Injectable({
  providedIn: 'root'
})
export class UserDataService {
  private libeyUser: LibeyUser = {
    documentNumber: '',
    documentTypeId: 1,
    name: '',
    fathersLastName: '',
    mothersLastName: '',
    address: '',
    regionCode: '',
    provinceCode: '',
    ubigeoCode: '',
    phone: '',
    email: '',
    password: '',
    active: true
  };

  constructor() { }

  setLibeyUser(user: LibeyUser) {
    this.libeyUser = user;
  }

  getLibeyUser(): LibeyUser {
    return this.libeyUser;
  }
}
