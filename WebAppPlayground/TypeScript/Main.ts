interface IPerson {
    firstName: string;
    lastName: string;
}

class Student {
    fullName: string;
    constructor(public firstName: string, public lastName: string) {
        this.fullName = lastName + ", " + firstName;
    }
}


function greeter(person: IPerson) {
    return "Hello, " + person.lastName;
}

var user = new Student("Sai", "Upadhyayula");
document.body.innerHTML = greeter(user);