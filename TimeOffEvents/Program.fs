//module TimeOff.TestsRunner

namespace TimeOff

module App =
    open Suave
    open Suave.Web

    (*
open Expecto

[<EntryPoint>]
let main args =
  runTestsWithArgs { defaultConfig with ``parallel`` = false } args Tests.tests
  *)

    [<EntryPoint>]
    let main argv =

        let repository = {
            GetAll = Db.getPeople
            GetById = Db.getPerson
            Create = Db.createPerson
            Update = Db.updatePerson
            UpdateById = Db.updatePersonById
            Delete = Db.deletePerson
            Exists = Db.personExists
        }

        let app =
            choose [
                Rest.RestFul.rest "people" repository
                RequestErrors.NOT_FOUND "Found no handlers"
            ]

        startWebServer defaultConfig app

        0