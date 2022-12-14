import { Component } from '@angular/core';
import { Person } from '../models/person';
import { PeopleService } from '../services/people.service';

@Component({
  selector: 'app-people-page',
  templateUrl: './people-page.component.html',
  styleUrls: ['./people-page.component.scss']
})
export class PeoplePageComponent {

  people: Person[] = [];

  constructor(private peopleService: PeopleService) {
    peopleService.getPeople().subscribe(res => {
      this.people = res;
    })
  }
}
