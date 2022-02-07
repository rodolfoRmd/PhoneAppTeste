import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {  PhoneTypeVO} from './phone-type-vo';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class PhoneTypeService {
  url = `${environment.UrlApi}/PhoneType`;

 constructor(private http: HttpClient) { }

 getAll(): Observable<PhoneTypeVO[]> {
   return this.http.get<PhoneTypeVO[]>(this.url);
 }
}

