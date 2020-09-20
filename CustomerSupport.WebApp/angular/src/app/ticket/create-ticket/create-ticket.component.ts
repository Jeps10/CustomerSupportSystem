import { Component, OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AssigneeService } from 'src/app/services/assignee.service';
import { IssueService } from 'src/app/services/issue.service';
import { PriorityService } from 'src/app/services/priority.service';
import { ProjectService } from 'src/app/services/project.service';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.scss']
})
export class CreateTicketComponent implements OnInit {

  id: number = -1;
  isEditing: boolean = false;

  projects: any[] = [];
  issues: any[] = [];
  assignees: any[] = [];
  priorities: any[] = [];

  formGroup: FormGroup;

  errors: any = {};

  constructor(
    private ticketService: TicketService,
    private projectService: ProjectService,
    private assigneeService: AssigneeService,
    private issueService: IssueService,
    private priorityService: PriorityService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {

    this.formGroup = new FormGroup({
      ProjectId: new FormControl(0),
      TypeId: new FormControl(0),
      PriorityId: new FormControl(0),
      AssigneeId: new FormControl(0),
      Description: new FormControl(''),
      Summary: new FormControl(''),
      DueDate: new FormControl(''),
      Reporter: new FormControl(''),
      OriginalEstimate: new FormControl(''),
    });

    this.assigneeService
      .getAll()
      .subscribe((assignees: any) => {

        this.assignees = assignees;

          this.issueService
          .getAll()
          .subscribe((issues: any) => {
            this.issues = issues;

            this.projectService
            .getAll()
            .subscribe((projects: any) => {
              this.projects = projects;

              this.priorityService
              .getAll()
              .subscribe((priorities: any) => {
                this.priorities = priorities;

                if(!this.router.url.endsWith("create")) {
                  this.isEditing = true;
                  this.activatedRoute
                    .params
                    .subscribe(params => {
                      this.id = +params.id;
                      this.ticketService
                        .get(this.id)
                        .subscribe((ticket: any) => {
                          this.formGroup = new FormGroup({
                            ProjectId: new FormControl(ticket.projectId),
                            TypeId: new FormControl(ticket.issueId),
                            PriorityId: new FormControl(ticket.priorityId),
                            AssigneeId: new FormControl(ticket.assigneeId),
                            Description: new FormControl(ticket.description),
                            Summary: new FormControl(ticket.summary),
                            DueDate: new FormControl(ticket.dueDate),
                            Reporter: new FormControl(ticket.reporter),
                            OriginalEstimate: new FormControl(ticket.originalEstimate),
                          });
                        });
                    });
                }
              });

            });

          });
  
      });
  }


  save(): void {

    let ticket = {
      ProjectId: parseInt(this.formGroup.get('ProjectId').value),
      IssueId: parseInt(this.formGroup.get('TypeId').value),
      PriorityId: parseInt(this.formGroup.get('PriorityId').value),
      AssigneeId: parseInt(this.formGroup.get('AssigneeId').value),
      Description: this.formGroup.get('Description').value,
      Summary: this.formGroup.get('Summary').value,
      DueDate: this.formGroup.get('DueDate').value,
      Reporter: this.formGroup.get('Reporter').value,
      OriginalEstimate: this.formGroup.get('OriginalEstimate').value,
    };

    if(this.id > -1) {
      ticket["Id"] = this.id;
      this.ticketService
        .update(ticket)
        .subscribe(
          (data: any) => {
            this.toastr.success('Successfully edited ticket!', 'Edit Ticket');
            this.router.navigate(['tickets']);
          },
          (errorResponse: any) => {
            this.errors = errorResponse.error;
            this.toastr.error('Error editing ticket!', 'Edit Ticket');
          }
        );
    }
    else {
      this.ticketService
      .create(ticket)
      .subscribe(
        (data: any) => {
          this.toastr.success('Successfully created ticket!', 'Create Ticket');
          this.router.navigate(['tickets']);
        },
        (errorResponse: any) => {
          this.errors = errorResponse.error;
          this.toastr.error('Error creating ticket!', 'Create Ticket');
        }
      );
    }
  }
}
