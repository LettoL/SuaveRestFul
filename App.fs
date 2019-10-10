open Suave.Web
open Suave.Successful
open SuaveRestApi.Db
open SuaveRestApi.Rest

[<EntryPoint>]
let main argv =
    let personWebPart = rest "people" {
      GetAll = Db.getPeople
    }
    startWebServer defaultConfig personWebPart
    0
