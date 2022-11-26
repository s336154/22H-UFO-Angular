import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Create} from './create/create';
import { Read } from './read/read';
import { Update } from './update/update';

const appRoots: Routes = [
  { path: 'read', component: Read },
  { path: 'create', component: Create },
  { path: 'update/:id', component: Update, },
  { path: '', redirectTo: 'read', pathMatch: 'full' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoots)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
