import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonPhoneComponent } from './person-phone/person-phone.component';

const routes: Routes = [
  { path: '', redirectTo: '/PersonPhone', pathMatch: 'full' },
  {path:"PersonPhone", component:PersonPhoneComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
