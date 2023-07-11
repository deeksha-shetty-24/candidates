import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CandidatesComponent } from './candidates/candidates.component';
import { CandidateFormComponent } from './candidate-form/candidate-form.component';

const routes: Routes = [
  { path: '', component: CandidatesComponent },
  { path: 'candidates/create', component: CandidateFormComponent },
  { path: 'candidates/edit/:id', component: CandidateFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
