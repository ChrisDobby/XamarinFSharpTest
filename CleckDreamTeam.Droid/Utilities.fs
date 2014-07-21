module CleckDreamTeam.Droid.Utilities

open System.IO
open System.Runtime.Serialization.Json
open System.Net.Http

let deserialiseJson<'a> (jsonStream : Stream) =
    let serialiser = new DataContractJsonSerializer(typedefof<'a>)
    serialiser.ReadObject(jsonStream) :?> 'a

let get<'a> (url : string) complete failed = 
    async {
        let clt = new HttpClient()

        try
            let! response = clt.GetAsync(url) |> Async.AwaitTask
            if response.StatusCode = System.Net.HttpStatusCode.OK then
                let! stream = response.Content.ReadAsStreamAsync() |> Async.AwaitTask

                complete (deserialiseJson<'a> stream)
            else
                failed
         with
            | _ -> failed
    }

let getPlayers complete failed =
    get<Player[]> "http://www.cleckdreamteam.co.uk/api/players" complete failed |> Async.RunSynchronously

let getPlayer id complete failed =
    get<Player> (sprintf "http://www.cleckdreamteam.co.uk/api/players/%s" id) complete failed |> Async.RunSynchronously

let getClubs complete failed =
    get<Club[]> "http://www.cleckdreamteam.co.uk/api/clubs" complete failed |> Async.RunSynchronously

let getClub id complete failed =
    get<Club> (sprintf "http://www.cleckdreamteam.co.uk/api/clubs/%s" id) complete failed |> Async.RunSynchronously
