import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GamePageComponent } from './pages/game-page/game-page.component';
import { StatisticsPageComponent } from './pages/statistics-page/statistics-page.component';
import { HeaderComponent } from './components/header/header.component';
import { TaskComponent } from './components/task/task.component';
import { StatisticComponent } from './components/statistic/statistic.component';

@NgModule({
  declarations: [
    AppComponent,
    GamePageComponent,
    StatisticsPageComponent,
    HeaderComponent,
    TaskComponent,
    StatisticComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
