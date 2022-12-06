import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PeoplePageComponent } from './people-page/people-page.component';
import { PersonEmailsComponent } from './person-emails/person-emails.component';

const routes: Routes = [
  { path: "", component: PeoplePageComponent },
  { path: "person/:id", component: PersonEmailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
