export class User {
}

export class Personaldetail {
    PersonalDetailID: number;
    UserName: string;
    FirstName: string;
    LastName: string;
    FatherName: string;
    MotherName: string;
    DOB: Date;
    NationalID: string;
    CellPhone: string;
    Email: string;
    Photo: string;
}
export class Addresses {
    AddressID: number;
    PresentAddress: string;
    PermanentAddress: string
    PersonalDetailID: number;
}
export class PutAddress {
    public addressViewModels: Array<Addresses>;
}
