import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Region } from "src/app/entities/region";
@Injectable({
	providedIn: "root",
})
export class RegionService {
	constructor(private http: HttpClient) {}
	
	Find(region: string | null): Observable<Region> {
		const uri = `${environment.pathLibeyTechnicalTest}region/${region}`;
		return this.http.get<Region>(uri);
	}

	FindAll(): Observable<Region[]> {
		const uri = `${environment.pathLibeyTechnicalTest}region/FindAllResponse`;
		return this.http.get<Region[]>(uri);
	}
}