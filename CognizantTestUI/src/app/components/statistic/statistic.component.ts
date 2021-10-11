import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../helpers/HTTPService';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.scss']
})
export class StatisticComponent implements OnInit {

  constructor(private httpClient: HttpService) { }
  statisticList: Array<any> = new Array<any>();

  ngOnInit(): void {
    this.httpClient.getData('Statistic').subscribe((data:any) => {
      this.statisticList = data;   
    });
  }
}