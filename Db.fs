namespace SuaveRestApi.Db

open System.Collections.Generic

type Person = {
  Id : int
  Name : string
  Age : int
  Email : string
}

module Db =
  let private peopleStorage = new Dictionary<int, Person>()
  let getPeople () =
    peopleStorage.Values :> seq<Person>
    
  let createPerson person =
    let id = peopleStorage.Values.Count + 1
    let newPerson = {person with Id = id}
    peopleStorage.Add(id, newPerson)
    newPerson
  
  let updatePersonByID personId personToBeUpdated =
    if peopleStorage.ContainsKey(personId) then
      let updatedPerson = {personToBeUpdated with Id = personId}
      peopleStorage.[personId] <- updatedPerson
      Some updatedPerson
    else
      None
  let updatePerson personToBeUpdated =
    updatePersonByID personToBeUpdated.Id personToBeUpdated
    
  let deletePerson personId =
    peopleStorage.Remove(personId) |> ignore
    
  let gerPerson id =
    if peopleStorage.ContainsKey(id) then
      Some peopleStorage.[id]
    else
      None
      
  let isPersonExists = peopleStorage.ContainsKey