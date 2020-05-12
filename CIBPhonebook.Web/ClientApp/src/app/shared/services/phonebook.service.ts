import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { ResponseMessageDto } from '../dtos/response.dto';
import { PhonebookDto } from '../dtos/phonebook.dto';
import { Observable } from 'rxjs';
import { Constant } from '../dtos/constant';

@Injectable({
  providedIn: 'root'
})
export class PhonebookService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
 
  AddPhoneBook(request: PhonebookDto): Observable<ResponseMessageDto> {
    const url = this.baseUrl + 'api/phonebook/addphonebook';
    return this.http.post<ResponseMessageDto>(url, request, Constant.httpOptions);
  }
  
  getPhoneEntries(): Observable<ResponseMessageDto> {
    const url = this.baseUrl + 'api/phonebook/getall';
    return this.http.get<ResponseMessageDto>(url, Constant.httpOptions);
  }

  getPhoneEntriesByName(name: string): Observable<ResponseMessageDto> {
     
    const params = new HttpParams()
      .set('name', name);
         
    const url = this.baseUrl + 'api/phonebook/getbyname?';
    return this.http.get<ResponseMessageDto>(url, {params: params});
  }
}
