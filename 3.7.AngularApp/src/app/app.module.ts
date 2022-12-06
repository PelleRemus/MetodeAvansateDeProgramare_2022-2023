import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { PeoplePageComponent } from './people-page/people-page.component';
import { PersonEmailsComponent } from './person-emails/person-emails.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    PeoplePageComponent,
    PersonEmailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
