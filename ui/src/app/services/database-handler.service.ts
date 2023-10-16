import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseStatus } from '../models/response-status.model';
import { TaskModifier } from '../models/task-modifier.model';

@Injectable({
  providedIn: 'root'
})
export class DatabaseHandlerService {

  private apiUrl: string = 'http://localhost:5030';

  constructor(
    private http: HttpClient
  ) {}

  getAllTasks(): Observable<ResponseStatus> {
    return this.http.get<ResponseStatus>(
      `${this.apiUrl}/tb01/`
    )
  }

  getTaskById(id: number): Observable<ResponseStatus> {
    return this.http.post<ResponseStatus>(
      `${this.apiUrl}/tb01/get_task_by_id/`, {id: id}
    )
  }

  updateTask(id: number, newTask: TaskModifier): Observable<ResponseStatus> {
    return this.http.put<ResponseStatus>(
      `${this.apiUrl}/tb01/update/`, {...newTask, id: id}
    )
  }

  deleteTask(id: number): Observable<ResponseStatus> {
    return this.http.post<ResponseStatus>(
      `${this.apiUrl}/tb01/delete/`, id
    )
  }

  createTask(newTask: TaskModifier): Observable<ResponseStatus> {
    return this.http.post<ResponseStatus>(
      `${this.apiUrl}/tb01/create/`, newTask
    )
  }
}
