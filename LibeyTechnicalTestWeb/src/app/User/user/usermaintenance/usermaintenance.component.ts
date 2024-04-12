import swal from 'sweetalert2';
import { Component, Injectable, OnInit } from '@angular/core';

import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { DocumentTypeService } from "src/app/core/service/documenttype/documenttype.service";
import { RegionService } from "src/app/core/service/region/region.service";
import { ProvinceService } from "src/app/core/service/province/province.service";
import { UbigeoService } from "src/app/core/service/ubigeo/ubigeo.service";
import { NgForm } from '@angular/forms';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { UserDataService } from '../userdataservice';
import { concatMap, switchMap } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
@Injectable({
  providedIn: 'root'
})

export class UsermaintenanceComponent implements OnInit {

  listDocumentType: any[] = [];

  listRegion: any[] = [];
  listProvince: any[] = [];
  listUbigeo: any[] = [];


  libeyUser: LibeyUser = {
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

  constructor(
    private router: Router,
    private userDataService: UserDataService,
    private libeyUserService: LibeyUserService,
    private documentTypeService: DocumentTypeService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService
  ) { }
  ngOnInit(): void {
    this.loadDocumentTypes();
    this.loadRegions();
    this.libeyUser = this.userDataService.getLibeyUser();
    this.onRegionChange(this.libeyUser.regionCode.length > 0 ? this.libeyUser.regionCode : ""
      ,this.libeyUser.provinceCode.length > 0 ? this.libeyUser.provinceCode : ""
      ,this.libeyUser.ubigeoCode.length > 0 ? this.libeyUser.ubigeoCode : "");

  }
  Submit() {
    // swal.fire("Oops!", "Something went wrong!", "error");
  }


  loadDocumentTypes() {
    this.documentTypeService.FindAll().subscribe(response => {
      this.listDocumentType = response;
    });
  }

  loadRegions() {
    this.regionService.FindAll().subscribe(response => {
      this.listRegion = response;
    });
  }

  onRegionChange(regionCode: any, regionSelected?: string, ubigeoSelected?: string) {
    this.provinceService.FindByRegion(regionCode).subscribe(provinces => {
      this.libeyUser.regionCode = regionCode;
      // this.libeyUser.provinceCode = ((this.libeyUser.provinceCode.length > 0) ? this.libeyUser.provinceCode : "");
      this.listProvince = provinces;

      // this.libeyUser.ubigeoCode = ((this.libeyUser.ubigeoCode.length > 0) ? this.libeyUser.ubigeoCode : "");
      this.listUbigeo = [];
      console.log(this.listProvince);

      this.onProvinceChange((regionSelected != null) ? regionSelected : (provinces.length > 0 ? provinces[0].provinceCode : ""), ubigeoSelected);
    });
  }

  onProvinceChange(provinceCode: any, ubigeoSelected?: string) {
    this.ubigeoService.FindByProvince((this.libeyUser.regionCode != null) ? this.libeyUser.regionCode : "", provinceCode).subscribe(ubigeo => {
      this.libeyUser.provinceCode = provinceCode;
      this.libeyUser.ubigeoCode =((ubigeoSelected != null) ? ubigeoSelected :  (ubigeo.length > 0 ? ubigeo[0].ubigeoCode : ""));
      this.listUbigeo = ubigeo;
      console.log(this.listUbigeo);
    });
  }


  saveLibey(form: NgForm) {
    if (form.valid) {
      console.log(this.libeyUser);
      this.libeyUserService.Save(this.libeyUser).subscribe(
        (response) => {
          console.log("Usuario guardado exitosamente:", response);

          swal.fire("Correcto", "Los datos han sido guardados!", "success");
          this.clearForm();
          this.router.navigate(['/user/list']);
        },
        (error) => {
          console.error("Error al guardar el usuario:", error);
          swal.fire("Advertencia", "Error al Guardar usuario", "error");

        }
      );
     
    } else {
      console.log("El formulario no es válido");
    }
  }



  clearForm() {
    this.libeyUser = {
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
      active: true,

    };
  }

  setLibeyUser(user: LibeyUser) {
    this.libeyUser = user;
  }

  getLibeyUser(): LibeyUser {
    return this.libeyUser;
  }

}