import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private SERVER_URL = "http://localhost:55879/api/Events";
  //private SERVER_URL = "http://localhost:3000";

  constructor(private httpClient: HttpClient) { }
  public get(){  
    return this.httpClient.get(this.SERVER_URL);  
  }
  public getEvent(eventId: any){  
    return this.httpClient.get(this.SERVER_URL + "/" + eventId);  
  }
}
