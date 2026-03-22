fn main() {
    let pet = Pet::Dog("CoolName".to_string());

    let message = match pet {
        Pet::Dog(name) => format!("It's a dog and their name is: {name}"),
        Pet::Cat(name) => format!("It's a cat and their name is: {name}"),
        Pet::Bird(name) => format!("It's a bird and their name is: {name}"),
    };

    println!("{}", message);
}

enum Pet {
    Dog(String),
    Cat(String),
    Bird(String)
}
