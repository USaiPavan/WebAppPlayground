var Student = (function () {
    function Student(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.fullName = lastName + ", " + firstName;
    }
    return Student;
}());
function greeter(person) {
    return "Hello, " + person.lastName;
}
var user = new Student("Sai", "Upadhyayula");
document.body.innerHTML = greeter(user);
