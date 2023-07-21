export interface Candidate {
  id: number;
  firstName: string;
  lastName: string;
  phoneNumber: number;
  email: string;
  address: string;
  experienceInYears: number;
  file: File;
  resumeFile: Blob
  fileName: string;
}
