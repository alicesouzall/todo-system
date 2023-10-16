import { Component, Inject} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TaskModifier } from 'src/app/models/task-modifier.model';
import { TaskTable } from 'src/app/models/task-table.model';
import { DatabaseHandlerService } from 'src/app/services/database-handler.service';

@Component({
  selector: 'app-dialog-add',
  templateUrl: './dialog-add.component.html',
  styleUrls: ['./dialog-add.component.css']
})
export class DialogAddComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: TaskTable,
    public dialogRef: MatDialogRef<DialogAddComponent>,
    private databaseHandler: DatabaseHandlerService,
  ) {
    if (this.data.id !== 0) {
      this.databaseHandler.getTaskById(this.data.id).subscribe((response) => {
        this.data = response.data

      })
    }
  }

  onSave(): void {
    const taskModifier: TaskModifier = {colTexto: this.data.colTexto}
    if (this.data.id == 0) {
      this.databaseHandler.createTask(taskModifier).subscribe((data) => {
        alert(data.message)
        window.location.reload()
      })
    }
    else {
      this.databaseHandler.updateTask(this.data.id, taskModifier).subscribe((data) => {
        alert(data.message)
        window.location.reload()
      })
    }
  }

  onClose(): void {
    this.data.colDt = ""
    this.data.colTexto = ""
    this.dialogRef.close()
  }
}
