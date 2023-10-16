import { Component } from '@angular/core';
import { TaskTable } from 'src/app/models/task-table.model';
import { DatabaseHandlerService } from 'src/app/services/database-handler.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  public tasks: TaskTable[] = [];
  constructor(
    private databaseHandler: DatabaseHandlerService
    ) {}

  ngOnInit(): void {
    this.databaseHandler.getAllTasks().subscribe((t) => {
      this.tasks = t.data;
    });
  }

}
