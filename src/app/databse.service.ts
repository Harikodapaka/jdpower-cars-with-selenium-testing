import { Injectable } from '@angular/core';
import { version } from 'punycode';

export interface VehicleInfo {
  sellerName: string;
  address: string;
  city: string;
  phoneNumber: string;
  email: string;
  vehicleMake: string;
  vehicleModel: string;
  vehicleYear: string;
}

const ELEMENT_DATA: VehicleInfo[] = [
  {sellerName: 'Hari', address: '100 Old carriage DR', city:'Kitchener', phoneNumber: '5197211259', email: 'hari@abc.com', vehicleMake:'Ford',vehicleModel:'Mustang-V6',vehicleYear:'2012'},
  {sellerName: 'Rahul', address: 'Conestoga College', city:'Waterloo', phoneNumber: '1234567890', email: 'rah@abc.com', vehicleMake:'Hyundai',vehicleModel:'Azera',vehicleYear:'2017'},
  {sellerName: 'Robart', address: 'Old carriage DR', city:'Kitchener', phoneNumber: '0980980989', email: 'robart@abc.com', vehicleMake:'Jaguar',vehicleModel:'F-TYPE',vehicleYear:'2018'},
  {sellerName: 'Rose', address: 'Fairview Park', city:'Toronto', phoneNumber: '1231231234', email: 'rose@cba.com', vehicleMake:'Dodge',vehicleModel:'Challenger',vehicleYear:'2018'}
];

@Injectable({
  providedIn: 'root'
})
export class DatabseService {

  constructor() {}

  SaveDummyData(){
    localStorage.setItem('vehicles', JSON.stringify(ELEMENT_DATA));
  }
  SaveVehicle(vehicle:VehicleInfo) {
    let x = localStorage.getItem('vehicles');
    var vehicles =  JSON.parse(x);
    vehicles.push(vehicle);
    localStorage.setItem('vehicles', JSON.stringify(vehicles));
  }
  GetSavedVehicles(): VehicleInfo[] {
    let x = localStorage.getItem('vehicles');
    return JSON.parse(x);
  }
  FilterVehicles(searchText: string, type: string): VehicleInfo[] {
    let x = localStorage.getItem('vehicles');
    var vehicles =  JSON.parse(x);
    let filteredVehicles = vehicles.filter(v=> v[type].toUpperCase() === searchText.toUpperCase());
    return filteredVehicles;
  }
}
