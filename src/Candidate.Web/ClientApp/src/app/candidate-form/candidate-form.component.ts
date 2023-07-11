import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-candidate-form',
  templateUrl: './candidate-form.component.html',
  styleUrls: ['./candidate-form.component.css']
})
export class CandidateFormComponent implements OnInit {

  candidateForm: FormGroup;
  isEdit: boolean = false;
  candidateId?: string;
  srcResult: any;

  constructor(
    private formBuilder: FormBuilder,
    private candidateService: CandidateService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.candidateForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      experienceInYears: ['', Validators.required],
      fileName: ['']
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdit = true;
      this.candidateId = id;
      this.getCandidate(id);
    }
  }

  getCandidate(id: string) {
    this.candidateService.getCandidateById(id).subscribe(candidate => {
      this.candidateForm.patchValue({
        ...candidate
      })
    })
  }

  onSubmit() {
    const candidate = this.candidateForm.value;
    if (this.isEdit && this.candidateId) {
      candidate.id = this.candidateId;
      this.candidateService.updateCandidate(this.candidateId, candidate).subscribe(() => {
        this.candidateForm.reset();
      });
    } else {
      candidate.id = Date.now().toString();
      this.candidateService.createCandidate(candidate).subscribe(() => {
        this.router.navigateByUrl('/');
      });
    }
  }

  onFileSelected() {
    const inputNode: any = document.querySelector('#file');
    this.candidateForm.get('fileName')?.patchValue(inputNode.files[0].name);
    if (typeof (FileReader) !== 'undefined') {
      const reader = new FileReader();

      reader.onload = (e: any) => {
        this.srcResult = e.target.result;
      };

      reader.readAsArrayBuffer(inputNode.files[0]);
    }
  }

}
