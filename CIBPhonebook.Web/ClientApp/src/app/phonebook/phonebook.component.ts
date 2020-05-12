import { Component, OnInit } from '@angular/core';
import { PhonebookService } from '../shared/services/phonebook.service';
import { PhonebookDto } from '../shared/dtos/phonebook.dto';

@Component({
  selector: 'app-phonebook',
  templateUrl: './phonebook.component.html',
  styleUrls: ['./phonebook.component.css']
})
export class PhonebookComponent implements OnInit {

  public data;
  constructor(private _phonebookservice: PhonebookService) {
    //this.GetAllPhoneBookEntries();
  }

  ngOnInit(): void {
  }

  public GetAllPhoneBookEntries() {
    this._phonebookservice.getPhoneEntries().subscribe(
      phonebookData => {
        this.data = phonebookData;
      },
      error => alert(error),
      () => console.log('phonebook data:', this.data)
    );
  }
  /*public GetPhoneBookBySearch(fullname, phonenumber) {
    this._phonebookservice.GetPhoneBookBySearch(fullname, phonenumber).subscribe(
      phonebookData => {
        this.data = phonebookData;
      },
      error => alert(error),
      () => console.log('phonebook by search data:', this.data)
    );
  }*/
  public CreatePhoneRecord(fullname, surname, phonenumber) {
    alert(fullname);
    var phonebook = new PhonebookDto(fullname, surname, phonenumber);
    this._phonebookservice.AddPhoneBook(phonebook);


}

}
