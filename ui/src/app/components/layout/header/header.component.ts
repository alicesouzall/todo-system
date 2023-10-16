import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TaskTable } from 'src/app/models/task-table.model';
import { DialogAddComponent } from '../../dialogs/dialog-add/dialog-add.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  public initialValues: TaskTable = {
    id: 0, colTexto: "", colDt: '00/00/0000'
  }

  constructor(
    public dialog: MatDialog
  ) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      data: this.initialValues,
    });

    dialogRef.afterClosed().subscribe(result => {
      this.initialValues.colDt = '00/00/0000'
      this.initialValues.colTexto = ""
    });
  }
}

