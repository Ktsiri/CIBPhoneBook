export class PhonebookDto {
    public FirstName: string;
    public Surname: string;
    public Phonenumber: string;

    constructor(firstname: string, surname: string, phonenumber: string) {
        this.FirstName = firstname.trim().replace('\n', '').replace('\n', '');
        this.Surname = surname.trim().replace('\n', '').replace('\n', '');
        this.Phonenumber = phonenumber.trim().replace('\n', '').replace('\n', '');
    }
}