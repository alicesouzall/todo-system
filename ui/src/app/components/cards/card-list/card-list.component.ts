import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TaskTable } from 'src/app/models/task-table.model';
import { DatabaseHandlerService } from 'src/app/services/database-handler.service';
import { DialogAddComponent } from '../../dialogs/dialog-add/dialog-add.component';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent {
  @Input()
  taskTable!: TaskTable;

  constructor(
    public dialog: MatDialog,
    private databaseHandler: DatabaseHandlerService
    ) {}

  deleteTask(id: number): void {
    this.databaseHandler.deleteTask(id).subscribe((data) => {
      alert(data.message)
      window.location.reload()
    })
  }

  openDialog(id: number): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      data: {
        id: id, colTexto: ""
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
    });
  }
}
