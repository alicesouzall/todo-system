import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TaskModifier } from 'src/app/models/task-modifier.model';
import { TaskTable } from 'src/app/models/task-table.model';
import { DialogAddComponent } from '../../dialogs/dialog-add/dialog-add.component';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent {
  public initialValues: TaskTable = {
    id: 1, col_texto: "teste", col_dt: '2020-01-01'
  }

  constructor(
    public dialog: MatDialog
  ) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      data: this.initialValues,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
    });
  }
}
