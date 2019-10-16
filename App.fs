open Suave.Web
open Suave.Successful
open SuaveRestApi.Db
open SuaveRestApi.Rest

[<EntryPoint>]
let main argv =
    let personWebPart = rest "people" {
      GetAll = Db.getPeople
      Create = Db.createPerson
      Update = Db.updatePerson
      Delete = Db.deletePerson
      GetById = Db.gerPerson
      UpdateById = Db.updatePersonByID
      IsExists = Db.isPersonExists
    }
    startWebServer defaultConfig personWebPart
    0
