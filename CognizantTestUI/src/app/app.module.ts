import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GamePageComponent } from './pages/game-page/game-page.component';
import { StatisticsPageComponent } from './pages/statistics-page/statistics-page.component';
import { HeaderComponent } from './components/header/header.component';
import { TaskComponent } from './components/task/task.component';
import { StatisticComponent } from './components/statistic/statistic.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpService } from './helpers/HTTPService';
import { ModalComponent } from './components/modal/modal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalService } from './helpers/modalService';

@NgModule({
  declarations: [
    AppComponent,
    GamePageComponent,
    StatisticsPageComponent,
    HeaderComponent,
    TaskComponent,
    StatisticComponent,
    ModalComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    NgbModule
  ],
  providers: [
    HttpService,
    ModalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
