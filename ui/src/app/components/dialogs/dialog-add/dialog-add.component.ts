import { Component, Inject} from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import { TaskModifier } from 'src/app/models/task-modifier.model';
import { TaskTable } from 'src/app/models/task-table.model';

@Component({
  selector: 'app-dialog-add',
  templateUrl: './dialog-add.component.html',
  styleUrls: ['./dialog-add.component.css']
})
export class DialogAddComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: TaskTable | TaskModifier,
    public dialogRef: MatDialogRef<DialogAddComponent>
  ) {}

  onClose = (): void => {
    console.log("aaaaaaaa", this.data)
    this.data.col_dt = null
    this.data.col_texto = ""
    this.dialogRef.close()
  }
}
