import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Shippers } from 'src/app/models/shippersInterface';
import { ShipperService } from 'src/app/service/shipper.service';

@Component({
  selector: 'app-shippers-table',
  templateUrl: './shippers-table.component.html',
  styleUrls: ['./shippers-table.component.css'],
})
export class ShippersTableComponent implements OnInit {
  
  formShipper:FormGroup;
  isFormMode: boolean = true;
  openForm: boolean = false;
  listShippers: Shippers[] = [];
  displayedColumns: string[] = ['id', 'companyName', 'phone', 'action'];
  dataSource = new MatTableDataSource(this.listShippers);

  constructor(private _shipperService: ShipperService, private fb: FormBuilder) {
    this.formShipper = this.fb.group({
      Id: [{value: '', disabled: true}],
      companyName: ['', Validators.required],
      phone: [''],
    });
  }

  ngOnInit(): void {
    this.getAllShippers();
  }

  onSubmitShipper(){
    this.isFormMode ? this.insertShipper() : this.editShipper()
  }

  insertShipper(){
    let shipperInsert: Shippers = {
      CompanyName: this.formShipper.get('companyName')?.value,
      Phone: this.formShipper.get('phone')?.value
    };
    this._shipperService.insertShipper(shipperInsert).subscribe(res => {
      this.formShipper.reset();
      this.getAllShippers();
      this.openForm = false;
    })
  }
  
  modalEditShipper(shipperElement: Shippers){
    this.openForm = true;
    this.isFormMode = false;
    this.formShipper.patchValue({
      Id: shipperElement.ShipperID,
      companyName: shipperElement.CompanyName,
      phone:shipperElement.Phone
    })
  }

  editShipper(){
    let shipperEdit: Shippers = {
      ShipperID: this.formShipper.get('Id')?.value,
      CompanyName:  this.formShipper.get('companyName')?.value,
      Phone: this.formShipper.get('phone')?.value
    }
    this._shipperService.editShipper(shipperEdit).subscribe(res=>{
      this.formShipper.reset();
      this.getAllShippers();
      this.isFormMode = true
      this.openForm = false;
    })
  }

  deleteShipper(id: number){
    this._shipperService.deleteShipper(id).subscribe(res=>{
      this.getAllShippers();
    })
  }

  getAllShippers() {
    this._shipperService.getAll().subscribe({
      next: (result) => {
        this.dataSource.data = result as Shippers[];
      },
      error: (e) => {
        console.log(e);
      },
    });
  }

  cancelForm(){
    this.isFormMode = true;
    this.openForm = false;
    this.formShipper.reset();
  }
}
