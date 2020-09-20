import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { CreateTicketComponent } from './create-ticket/create-ticket.component';
import { ListTicketComponent } from './list-ticket/list-ticket.component';

const routes: Routes = [
    {
      path: 'tickets',
      children: [
        {
          path: '',
          component: ListTicketComponent
        },
        {
          path: 'create', // child route path
          component: CreateTicketComponent, // child route component that the router renders
        },
        {
          path: ':id',
          component: CreateTicketComponent, // another child route component that the router renders
        }
      ]
    },
    {
      path: '**',
      redirectTo: 'tickets'
    }
  ];

  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class TicketRoutingModule { }