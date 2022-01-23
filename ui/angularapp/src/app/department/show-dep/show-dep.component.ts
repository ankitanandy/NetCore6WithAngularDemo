import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  DepartmentList:any=[];
  ModalTitle:string="";
  ActivateAddEditDepComp:boolean=false;
  dep:any;

  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  addClick(){
    this.dep=
    {
      DepartmentId:0,
      DepartmentName:""
    }
    this.ModalTitle="Add Department";
    this.ActivateAddEditDepComp=true;
  }

  editClick(){
    this.dep=
    {
      DepartmentId:0,
      DepartmentName:""
    }
    this.ModalTitle="Update Department";
    this.ActivateAddEditDepComp=true;
  }

  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refreshDepartmentList();
  }

  refreshDepartmentList(){
    this.service.getDepartmentList().subscribe(data=>{
      this.DepartmentList=data;
    })
  }

}
