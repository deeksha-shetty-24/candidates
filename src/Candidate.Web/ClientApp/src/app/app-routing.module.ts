import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CandidateComponent } from './candidates/candidate.component';
import { CandidateFormComponent } from './candidates/components/candidate-form/candidate-form.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
  {
    path: '',
    redirectTo: 'candidate',
    pathMatch: 'full',
  },
  {
    path: 'candidate',
    loadChildren: () => import('./candidates/candidate.module').then(m => m.CandidateModule),
    canActivate: [AuthGuard]
  },
  // {
  //   path: 'candidates/create',
  //   component: CandidateFormComponent,
  //   canActivate: [AuthGuard]
  // },
  // {
  //   path: 'candidates/edit/:id',
  //   component: CandidateFormComponent,
  //   canActivate: [AuthGuard]
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
