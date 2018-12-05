import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DatabseService, VehicleInfo } from './databse.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { AddDialogComponent } from './add-dialog/add-dialog.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  dataSource;
  displayedColumns: string[];
  options: any[] = [
    { name: 'Make', key: 'vehicleMake' },
    { name: 'Year', key: 'vehicleYear' },
    { name: 'Model', key: 'vehicleModel' },
    { name: 'City', key: 'city' }
  ];

  constructor(private database: DatabseService,
    public dialog: MatDialog
    ) { }
  ngOnInit() {
    localStorage.clear();
    this.database.SaveDummyData();
    this.displayedColumns = ['VehicleMake', 'VehicleModel','VehicleYear', 'SellerName', 'City'];
    this.dataSource = this.database.GetSavedVehicles();
  }
  searchTextControl = new FormControl('', [Validators.required]);
  optionControl = new FormControl('', [Validators.required]);
  selectFormControl = new FormControl('', Validators.required);

  openDialog(): void {
    let dialogRef = this.dialog.open(AddDialogComponent, {
      width: '49%',
      disableClose:true,
      data: {'state': 'Add'}
    });

    dialogRef.afterClosed().subscribe(result => {
        result.state='';
        result.vehicleMake = result.vehicleMake.toLowerCase().replace(/ /g, '-');
        result.vehicleModel = result.vehicleModel.toLowerCase().replace(/ /g, '-');
        result.vehicleMake = result.vehicleMake.toUpperCase();
        
        this.database.SaveVehicle(result);
        this.dataSource = this.database.GetSavedVehicles();
    });
  }
  FilterVehicles(){
    let search = this.searchTextControl.value;
    let type = this.optionControl.value;
    this.dataSource = this.database.FilterVehicles(search,type);
  }
  isButtonDisabled(): boolean{
    let res:boolean = true;
    if(this.searchTextControl.value && this.optionControl.value)
      res = false;
    return res;
  }
  ShowDetails(Vehicle: VehicleInfo){
    let dialogRef = this.dialog.open(AddDialogComponent, {
      width: '49%',
      disableClose:true,
      data: Vehicle
    });

    dialogRef.afterClosed().subscribe(result => {
      
    });
  }
  // getErrorMessage() {
  //   return this.email.hasError('required') ? 'You must enter a value' :
  //     this.email.hasError('email') ? 'Not a valid email' :
  //       '';
  // }

}
