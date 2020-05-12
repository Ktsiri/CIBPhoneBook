import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PhonebookComponent } from './phonebook.component';

const routes: Routes = [
  { path: 'phonebook', component: PhonebookComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PhonebookRoutingModule { }
