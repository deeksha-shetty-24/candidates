import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from '../../services/candidate.service';
import { Candidate } from '../../models/candidate.model';

@Component({
  selector: 'app-candidate-form',
  templateUrl: './candidate-form.component.html',
  styleUrls: ['./candidate-form.component.css']
})
export class CandidateFormComponent implements OnInit {

  candidateForm: FormGroup;
  isEdit: boolean = false;
  srcResult: any;
  selectedFile: File;
  filePreview: string | ArrayBuffer | null = null;
  candidate: Candidate;
  fileName: string;
  isNewFileSelected: boolean;
  blob: Blob;
  submitDisplayName: string = "Save";
  invalidFile: boolean;
  constructor(
    private formBuilder: FormBuilder,
    private candidateService: CandidateService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.candidateForm = this.formBuilder.group({
      id: [0],
      firstName: ['', Validators.required],
      lastName: [''],
      phoneNumber: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      experienceInYears: ['', Validators.required],
      file: [''],
      fileName: ['']
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.submitDisplayName = "Update";
      this.isEdit = true;
      this.getCandidate(id);
    }
  }

  get m() {
    return this.candidateForm.controls;
  }

  getCandidate(id: string) {
    this.candidateService.getCandidateById(id).subscribe(candidate => {
      this.candidate = candidate;
      this.candidateForm.patchValue({
        ...candidate
      });
      this.fileName = candidate.fileName;
      this.candidateService.downloadCandidate(this.candidate.id).subscribe((data: any) => {
        this.blob = new Blob([data], {
          type: "application/octate-stream",
        });
      });
    })
  }

  onSubmit() {
    const formData: FormData = new FormData();
    if (this.isNewFileSelected) {
      this.candidate.fileName = this.selectedFile.name;
      formData.append('file', this.selectedFile, this.selectedFile.name);
    }
    else {
      let file = new File([this.blob], this.candidate.fileName);
      formData.append('file', file, file.name);
    }

    this.candidate = { ...this.candidateForm.value };
    if (!this.candidateForm.valid) {
      return;
    }
    else if (!this.candidate.fileName) {
      this.invalidFile = true;
      return;
    }

    this.candidateService.createCandidate(this.candidate, formData).subscribe(() => {
      this.router.navigateByUrl('/');
    });
  }

  onFileSelected(event: any) {
    this.isNewFileSelected = true;
    let selectedFile = event.target.files[0] as File;
    if (selectedFile.type == "application/pdf") {
      this.invalidFile = false;
      this.selectedFile = selectedFile;
      this.fileName = event.target.files[0].name;
      // Display file preview
      const reader = new FileReader();
      reader.onload = () => {
        this.filePreview = reader.result;
      };
      reader.readAsDataURL(this.selectedFile);
    }
    else {
      this.invalidFile = true;
    }
  }

  downloadFile() {
    const url = window.URL.createObjectURL(this.blob);
    const link = document.createElement("a");
    link.href = url;
    link.setAttribute("download", this.candidate.fileName);
    link.click();;
  }

  onCancel() {
    this.router.navigateByUrl('/');
  }
}
