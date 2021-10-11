import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamePageComponent } from './pages/game-page/game-page.component';
import { StatisticsPageComponent } from './pages/statistics-page/statistics-page.component';

const routes: Routes = [
  {path: '', redirectTo: '/task', pathMatch: 'full'},
  {path: 'task', component: GamePageComponent},
  {path: 'stats', component: StatisticsPageComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
