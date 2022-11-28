import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Create} from './create/create';
import { List } from './list/list';
import { Update } from './update/update';

const appRoots: Routes = [
  { path: 'list', component: List },
  { path: 'create', component: Create },
  { path: 'update/:id', component: Update, },
  { path: '', redirectTo: 'list', pathMatch: 'full' }
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
