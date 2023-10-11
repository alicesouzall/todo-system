import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TaskModifier } from 'src/app/models/task-modifier.model';
import { DialogAddComponent } from '../../dialogs/dialog-add/dialog-add.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  public initialValues: TaskModifier = {
    col_texto: "", col_dt: null
  }

  constructor(
    public dialog: MatDialog
  ) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogAddComponent, {
      data: this.initialValues,
    });

    dialogRef.afterClosed().subscribe(result => {
      this.initialValues.col_dt = null
      this.initialValues.col_texto = ""
    });
  }
}

