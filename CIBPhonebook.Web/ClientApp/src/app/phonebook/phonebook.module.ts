import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PhonebookRoutingModule } from './phonebook-routing.module';
import { PhonebookComponent } from './phonebook.component';



@NgModule({
  declarations: [PhonebookComponent],
  imports: [
    CommonModule,
    PhonebookRoutingModule
  ]
})
export class PhonebookModule { }
