import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Personaldetail, Addresses, PutAddress } from '../../models/user.model';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  personalInfoForm: FormGroup;
  addressForm: FormGroup;
  peseronalInfoId: number;
  personalInfo: Personaldetail = new Personaldetail();
  addressinfo: Addresses[] = [];
  putAddressModel: PutAddress = new PutAddress();
  submitted: boolean = false;
  constructor(private _fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute,
    private personService: UserService) {
    this.personalInfoForm = this._fb.group({
      PersonalDetailID: [0],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      FatherName: ['', Validators.required],
      MotherName: ['', Validators.required],
      DOB: ['', Validators.required],
      NationalID: ['', Validators.required],
      CellPhone: ['', Validators.required],
      Email: ['', Validators.required],
      Addresses:
        this.addressForm = this._fb.group({
          AddressID: [0],
          PresentAddress: [''],
          PermanentAddress: [''],
          PersonalDetailID: [''],
        })
    });
    this.addressForm = this._fb.group({
      address: this._fb.array([
        this.addAddressForm()
      ]),
    });
  }
  addAddressForm(): FormGroup {
    return this._fb.group({
      AddressID: [0],
      PresentAddress: ['', Validators.required],
      PermanentAddress: ['', Validators.required],
      PersonalDetailID: [0],
    })
  }
  // convenience getter for easy access to form fields
  get f() { return this.personalInfoForm.controls; }
  get a() { return this.addressForm.controls; }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(param => {
      this.peseronalInfoId = +param.get("id");
      console.log(this.peseronalInfoId)
      if (this.peseronalInfoId > 0) {
        let eduQulaFormArray = <FormArray>this.addressForm.get('address');
        this.personService.getById(this.peseronalInfoId).subscribe((res: any) => {
          console.log(res);
          this.personalInfo = res.obj;
          this.addressinfo = res.obj.Addresses;
          console.log(this.addressinfo)
          this.personalInfoForm.patchValue(this.personalInfo);
          eduQulaFormArray.patchValue(this.addressinfo);
        }, e => {
          console.log(e.error)
        })
      }
    })
  }
  onSubmit() {
    if (this.submitted = true) {
      this.personalInfoForm.markAllAsTouched();
      console.log(this.personalInfoForm.value)
      if (this.personalInfoForm.valid) {
        this.personalInfo = this.personalInfoForm.value;
        console.log(this.personalInfo);
        if (this.peseronalInfoId > 0) {
          this.personService.update(this.personalInfo).subscribe((res: any) => {
            console.log(res);
            alert(res.message)
          })
        }
      }
      else {
        e => {
          console.log(e.error);
        }
      }
    }
    this.router.navigateByUrl("/user/profile")
  }
  saveAddress() {
    let addressArrayForm = <FormArray>this.addressForm.get('address');
    console.log(addressArrayForm.value);
    if (addressArrayForm.valid) {
      for (let i = 0; i < addressArrayForm.length; i++) {
        // eduQulaFormArray.at(i).get('employeeId').setValue(this.employee.id);
        // console.log(this.employee.id);
        this.putAddressModel.addressViewModels = addressArrayForm.value;
        console.log("Sawon")
        console.log(this.putAddressModel)
      }
      if (this.putAddressModel != null) {
        if (addressArrayForm.at(0).get('PersonalDetailID').value > 0) {
          this.personService.addUpdate(this.putAddressModel.addressViewModels).subscribe((res: any) => {
            console.log(res);
            alert(res.message)
          });
        }
      }
    }
    this.router.navigateByUrl("/user/profile")
  }
  clickCan() {
    this.router.navigateByUrl("/user/profile")
  }
}