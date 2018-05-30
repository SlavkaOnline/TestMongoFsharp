namespace Domain

type Person = {
    Id: string;
    Name: string
}

type IRepository = 
    abstract member getPerson: Person with get 
    abstract member addPerson: Person -> unit
    
module Command =     
    let getPersonFromDb (db: IRepository) = 
        db.getPerson