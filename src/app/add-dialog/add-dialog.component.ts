import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {VehicleInfo} from '../databse.service';

@Component({
  selector: 'app-add-dialog',
  templateUrl: './add-dialog.component.html',
  styleUrls: ['./add-dialog.component.css']
})
export class AddDialogComponent {
  link:string;
  constructor(
  public dialogRef: MatDialogRef<AddDialogComponent>,
  @Inject(MAT_DIALOG_DATA) public data: VehicleInfo) {
    if(data.sellerName){
      this.SellerNameControl.disable();
      this.AddressControl.disable();
      this.CityControl.disable();
      this.PhoneControl.disable();
      this.EmailControl.disable();
      this.MakeControl.disable();
      this.ModelControl.disable();
      this.YearControl.disable();
      this.link = `https://www.jdpower.com/Cars/${data.vehicleYear}/${data.vehicleMake}/${data.vehicleModel}`
    }
  }
  
  SellerNameControl = new FormControl('', [Validators.required, Validators.maxLength(20)]);
  AddressControl = new FormControl('', [Validators.required, Validators.maxLength(20)]);
  CityControl = new FormControl('', [Validators.required, Validators.maxLength(10)]);
  PhoneControl = new FormControl('', [Validators.required, Validators.pattern(/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/)]);
  EmailControl = new FormControl('', [Validators.required,Validators.pattern(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/)]);
  MakeControl = new FormControl('', [Validators.required, Validators.maxLength(15)]);
  ModelControl = new FormControl('', [Validators.required, Validators.maxLength(15)]);
  YearControl = new FormControl('', [Validators.required, Validators.maxLength(4)]);

  isButtonDisbled(): boolean{
    let res = true
    if(this.SellerNameControl.value && this.AddressControl.value && this.CityControl.value &&
      this.PhoneControl.value && this.EmailControl.value && this.MakeControl.value
      && this.ModelControl.value && this.YearControl.value)
      res =  false;
    if(this.SellerNameHasError() || this.AddressHasError() || this.CityHasError() ||
      this.PhoneHasError() || this.EmailHasError() || this.MakeHasError()
      || this.ModelHasError() || this.YearHasError())
      res =  false;
    return res;
  }
  SellerNameHasError(){
    return this.SellerNameControl.hasError('maxlength')? true:false;
  }
  AddressHasError(){
    return this.SellerNameControl.hasError('maxlength')? true:false;
  }
  CityHasError(){
    return this.SellerNameControl.hasError('maxlength')? true:false;
  }
  PhoneHasError(){
    return this.SellerNameControl.hasError('pattern')? true:false;
  }
  EmailHasError(){
    return this.SellerNameControl.hasError('pattern')? true:false;
  }
  MakeHasError(){
    return this.SellerNameControl.hasError('maxlength')? true:false;
  }
  ModelHasError(){
    return this.SellerNameControl.hasError('maxlength')? true:false;
  }
  YearHasError(){
    return this.SellerNameControl.hasError('maxlength')? true:false;
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  NavigateToSite(){
    var newWindow = window.open(this.link);
  }
}
