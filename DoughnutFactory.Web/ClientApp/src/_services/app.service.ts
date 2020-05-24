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
  constructor(private httpClient: HttpClient) {
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
}
