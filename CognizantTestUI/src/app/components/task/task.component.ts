import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/helpers/HTTPService';
import { ModalService } from 'src/app/helpers/modalService';
import { CompletedTaskModel } from 'src/app/models/CompletedTaskModel';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss']
})
export class TaskComponent implements OnInit {

  constructor(
    private httpClient: HttpService,
    private confirmationDialogService: ModalService) {  }
  tmp = "";
  taskDescriptionAndParams : {
    taskDescriptipon: string,
    taskParams: string
  } = {taskDescriptipon : "", taskParams : ""}
  taskList: Array<any> = new Array<any>();

  CompletedTask: CompletedTaskModel = new CompletedTaskModel();

  ngOnInit(): void {
      this.httpClient.getData('task').subscribe((data:any) => {
        console.log(data)
        this.taskList = data;   
      });
      
  }
  public getTaskData(id: string){
    this.CompletedTask.SelectedTaskId = Number(id);
    this.httpClient.getData('task/' + id).subscribe((data:any) => {
      console.log(data)
      this.taskDescriptionAndParams.taskDescriptipon = data.description;   
      this.taskDescriptionAndParams.taskParams = data.parameters;   
    });
  }

  public postTaskSolution(){
    this.httpClient.postData('task', JSON.stringify(this.CompletedTask)).subscribe((data: any) => {
      this.confirmationDialogService
      .confirm(data.isCorrect? "Correct" : "Mistake", data.result)});
  }
  updateSolutionString(e:any) {
    this.CompletedTask.SolutionString = e.target.textContent;
  }
}
