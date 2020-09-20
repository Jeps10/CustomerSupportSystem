import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-list-ticket',
  templateUrl: './list-ticket.component.html',
  styleUrls: ['./list-ticket.component.scss'],
  providers: [TicketService]
})
export class ListTicketComponent implements OnInit {

  tickets: any[] = [];
  loading: boolean = false;

  constructor(
    private ticketService: TicketService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.loading = true;
    this.ticketService
      .getAll()
      .subscribe((data: any) => {
        this.tickets = data;
        this.loading = false;
      });
  }

  create(): void {
    this.router.navigate(['tickets', 'create']);
  }

  edit(id: number): void {
    this.router.navigate(['tickets', id]);
  }

  delete(id: number): void {
    this.ticketService
      .delete(id)
      .subscribe(
        (data: any) => {
          let idx = this.tickets.findIndex(t => t.id == id);
          if(idx > -1) {
            this.toastr.success('Successfully deleted ticket!', 'Delete Ticket');
            this.tickets.splice(idx, 1);
          }
        },
        (errorResponse: any) => {
          this.toastr.error(errorResponse.error["Id"], 'Delete Ticket');
        }
      )
  }

}
