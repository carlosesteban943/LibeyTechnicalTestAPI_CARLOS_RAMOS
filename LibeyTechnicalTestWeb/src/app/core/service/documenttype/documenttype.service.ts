import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { DocumentType } from "src/app/entities/documenttype";
@Injectable({
	providedIn: "root",
})
export class DocumentTypeService {
	constructor(private http: HttpClient) {}
	
	Find(documentType: string | null): Observable<DocumentType> {
		const uri = `${environment.pathLibeyTechnicalTest}documenttype/${documentType}`;
		return this.http.get<DocumentType>(uri);
	}

	FindAll(): Observable<DocumentType[]> {
		const uri = `${environment.pathLibeyTechnicalTest}documenttype/FindAllResponse`;
		return this.http.get<DocumentType[]>(uri);
	}
}