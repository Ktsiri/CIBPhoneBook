import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from '../app-routing.module';



@NgModule({
  declarations: [NavMenuComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports: [NavMenuComponent]
})
export class SharedModule { }
