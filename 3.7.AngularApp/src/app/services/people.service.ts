import { Injectable } from '@angular/core';
import { Person } from '../models/person';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  people: Array<Person> = [
    { id: 1, firstName: "Remus-Nicolae", lastName: "Pelle", nickName: "Nicholas" } as Person,
    { id: 2, firstName: "Norbert", lastName: "Bardas", nickName: "Norbi" } as Person,
    { id: 3, firstName: "Marcela", lastName: "Popa-Bota", nickName: "Marci" } as Person,
  ];
  baseUrl = "https://localhost:44334/api/People";

  constructor(private client: HttpClient) { }

  getPeople(): Observable<Person[]> {
    return this.client.get<Person[]>(this.baseUrl);
  }
}
