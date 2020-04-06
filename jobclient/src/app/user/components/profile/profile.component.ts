import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Personaldetail } from '../../models/user.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  personList: any;
  personListAd: [] = [];

  constructor(private service: UserService) { }
  ngOnInit() {
    this.service.getPersonalInfo().subscribe((res: any) => {
      this.personList = res.obj;
      console.log(this.personList)
    });
  }
  populateForm(details: Personaldetail) {
    this.personList = Object.assign({}, details);
  }



  // onDelete(id: any) {
  //   if (confirm('Are You Sure??')) {
  //     console.log(id);
  //     this.service.deleteDetails(id).subscribe(x => {
  //       //  console.log(x), this.service.refreshList();
  //     });
  //   }
  // }

}


