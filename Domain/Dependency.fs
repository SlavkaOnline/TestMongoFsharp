namespace Domain

type Person = {
    Id: string;
    Name: string
}

type Animal = {
    Id: string;
    NickName: string;
    
}


type Entity = 
    | Person of Person
    | Animal of Animal

type IRepository = 
    abstract member getPerson: Person with get 
    abstract member addPerson: Person -> unit
 
type IEntityRepository = 
     abstract member addAnimal: Animal -> unit
     abstract member getAnimal: Id: string -> Animal  
     abstract member addPerson: Person -> unit
     abstract member getPerson: Id: string -> Person
    
module Command =     
    let getPersonFromDb (db: IRepository) = 
        db.getPerson
    let getAnimalFromDb (db: IEntityRepository) id =
        db.getAnimal id
    let getPerson2FromDb (db: IEntityRepository) id =
        db.getPerson id