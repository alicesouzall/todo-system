import { ComponentType } from '@angular/cdk/portal';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TaskModifier } from '../models/task-modifier.model';

// @Injectable()
export class DialogService {
//   public initialValues: TaskModifier;

    constructor(
        // public dialog: MatDialog,
        // public initialValues: TaskModifier
    ) {
        // Inicialize os valores iniciais aqui, se necessário
    }

    // public openDialog(data: TaskModifier, dialogToOpen: ComponentType<unknown>): void {
        // const dialogRef = this.dialog.open(dialogToOpen, {
        //     data: data
        // });

        // dialogRef.afterClosed().subscribe(result => {
        //     console.log(result);
        // });
    // }
}
