import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskPageComponent } from './pages/task-page/task-page.component';
import { StatisticsPageComponent } from './pages/statistics-page/statistics-page.component';

const routes: Routes = [
  {path: '', redirectTo: '/task', pathMatch: 'full'},
  {path: 'task', component: TaskPageComponent},
  {path: 'stats', component: StatisticsPageComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
