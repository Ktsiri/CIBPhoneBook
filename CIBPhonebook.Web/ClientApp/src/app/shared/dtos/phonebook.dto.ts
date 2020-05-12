export class PhonebookDto {
    public FullName: string;
    public Surname: string;
    public Phonenumber: string;

    constructor(fullname: string, surname: string, phonenumber: string) {
        this.FullName = fullname.trim().replace('\n', '').replace('\n', '');
        this.Surname = surname.trim().replace('\n', '').replace('\n', '');
        this.Phonenumber = phonenumber.trim().replace('\n', '').replace('\n', '');
    }
}