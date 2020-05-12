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
  public GetPhoneBookByName(name) {
    this._phonebookservice.getPhoneEntriesByName(name).subscribe(
      phonebookData => {
        this.data = phonebookData;
      },
      error => alert(error),
      () => console.log('phonebook by search data:', this.data)
    );
  }
  public CreatePhoneRecord(firstname, surname, phonenumber) {
    var phonebook = new PhonebookDto(firstname, surname, phonenumber);
    this._phonebookservice.AddPhoneBook(phonebook).subscribe();
  }

}
