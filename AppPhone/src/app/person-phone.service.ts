import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonPhoneVO } from './person-phone-vo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonPhoneService {
   url = `${environment.UrlApi}/PersonPhone`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<PersonPhoneVO[]> {
    return this.http.get<PersonPhoneVO[]>(this.url);
  }

  post(personPhone: PersonPhoneVO) {
    return this.http.post(this.url, personPhone);
  }

  put(personPhone: PersonPhoneVO) {
    return this.http.put(this.url, personPhone);
  }

  del(id:number){
    return this.http.delete(`${this.url}/${id}`);
  }
}
