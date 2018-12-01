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
        this.SellecerNameControl.disable();
        this.AddressControl.disable();
        this.CityControl.disable();
        this.PhoneControl.disable();
        this.EmailControl.disable();
        this.MakeControl.disable();
        this.ModelControl.disable();
        this.YeraControl.disable();
        this.link = `https://www.jdpower.com/Cars/${data.vehicleYear}/${data.vehicleMake}/${data.vehicleModel}`
      }
    }
    
  SellecerNameControl = new FormControl('', [Validators.required]);
  AddressControl = new FormControl('', [Validators.required]);
  CityControl = new FormControl('', [Validators.required]);
  PhoneControl = new FormControl('', [Validators.required]);
  EmailControl = new FormControl('', [Validators.required,Validators.email]);
  MakeControl = new FormControl('', [Validators.required]);
  ModelControl = new FormControl('', [Validators.required]);
  YeraControl = new FormControl('', [Validators.required]);

  onNoClick(): void {
    this.dialogRef.close();
  }
  NavigateToSite(){
    var newWindow = window.open(this.link);
  }
}
