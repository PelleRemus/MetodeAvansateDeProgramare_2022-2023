import { Component } from '@angular/core';
import { Person } from '../models/person';

@Component({
  selector: 'app-people-page',
  templateUrl: './people-page.component.html',
  styleUrls: ['./people-page.component.scss']
})
export class PeoplePageComponent {

  people: Array<Person> = [
    { id: 1, firstName: "Remus-Nicolae", lastName: "Pelle", nickName: "Nicholas" } as Person,
    { id: 2, firstName: "Norbert", lastName: "Bardas", nickName: "Norbi" } as Person,
    { id: 3, firstName: "Marcela", lastName: "Popa-Bota", nickName: "Marci" } as Person,
  ];
}
