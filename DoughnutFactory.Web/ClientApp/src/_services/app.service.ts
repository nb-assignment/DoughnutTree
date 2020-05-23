import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { DoughnutTree } from '../_models/DoughnutTree';
import { DoughnutTreeNode } from '../_models/DoughnutTreeNode';

@Injectable({
  providedIn: 'root'
})

export class AppService {
  headers: any;
  constructor(private httpClient: HttpClient) {
    this.headers = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    }
  }

  getDoughnutTree(): Observable<DoughnutTree>{
    var endpoint = environment.endpoint + "/doughnuttreenode";
    return this.httpClient.get<DoughnutTree>(endpoint);
  }

  getFirstNode(): Observable<DoughnutTreeNode> {
    var endpoint = environment.endpoint + "/doughnuttreenode/firstNode";
    return this.httpClient.get<DoughnutTreeNode>(endpoint);
  }

  getNodeById(id): Observable<DoughnutTreeNode> {
    var endpoint = environment.endpoint + "/doughnuttreenode/" + id;
    return this.httpClient.get<DoughnutTreeNode>(endpoint);
  }

  updateChoiceService(obj: any) {
    var endpoint = environment.endpoint + "helper/updatechoice";
    return this.httpClient.post(endpoint, obj, this.headers);
  }

  getChoiceService() {
    var endpoint = environment.endpoint + "helper/getchoice";
    return this.httpClient.get(endpoint, this.headers);
  }

  clearDatabaseChoiceService() {
    var endpoint = environment.endpoint + "helper/clearchoice";
    return this.httpClient.get(endpoint, this.headers);
  }
}
