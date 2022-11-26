import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { Create } from './create/create';
import { Read } from './read/read';
import { Update } from './update/update';
import { Menu } from './menu/menu';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Modal } from './read/deleteModal';

@NgModule({
  declarations: [
    AppComponent,
    Create,
    Read,
    Update,
    Menu,
    Modal
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [Modal] // merk!  
})
export class AppModule { }
