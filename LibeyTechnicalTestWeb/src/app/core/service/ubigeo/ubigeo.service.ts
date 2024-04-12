import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Ubigeo } from "src/app/entities/ubigeo";
@Injectable({
	providedIn: "root",
})
export class UbigeoService {
	constructor(private http: HttpClient) {}
	
	Find(ubigeo: string | null): Observable<Ubigeo> {
		const uri = `${environment.pathLibeyTechnicalTest}ubigeo/${ubigeo}`;
		return this.http.get<Ubigeo>(uri);
	}

	FindByProvince(regionCode: string, provinceCode: string ): Observable<Ubigeo[]> {
		const uri = `${environment.pathLibeyTechnicalTest}ubigeo/FindByProvince?regionCode=${regionCode}&provinceCode=${provinceCode}`;
		return this.http.get<Ubigeo[]>(uri);
	}
}