namespace CleckDreamTeam.Droid

open System.Runtime.Serialization

[<DataContract>]
type Club() =
    let mutable id = 0
    let mutable name = ""
    let mutable division = 0
    let mutable notAvailable = false
    let mutable runs = 0
    let mutable wickets = 0
    let mutable victims = 0
    [<DataMember>]
    member this.ClubId with get() = id and set(v) = id <- v
    [<DataMember>]
    member this.Name with get() = name and set(v) = name <- v
    [<DataMember>]
    member this.Division with get() = division and set(v) = division <- v
    [<DataMember>]
    member this.NotAvailable with get() = notAvailable and set(v) = notAvailable <- v
    [<DataMember>]
    member this.Runs with get() = runs and set(v) = runs <- v
    [<DataMember>]
    member this.Wickets with get() = wickets and set(v) = wickets <- v
    [<DataMember>]
    member this.Victims with get() = victims and set(v) = victims <- v

[<DataContract>]
type Player () =
    let mutable id = 0
    let mutable name = ""
    let mutable club = ""
    let mutable surname = ""
    let mutable notAvailable = false
    let mutable runs = 0
    let mutable wickets = 0
    let mutable victims = 0
    [<DataMember>]
    member this.PlayerId with get() = id and set(v) = id <- v
    [<DataMember>]
    member this.Name with get() = name and set(v) = name <- v
    [<DataMember>]
    member this.Club with get() = club and set(v) = club <- v
    [<DataMember>]
    member this.Surname with get() = surname and set(v) = surname <- v
    [<DataMember>]
    member this.NotAvailable with get() = notAvailable and set(v) = notAvailable <- v
    [<DataMember>]
    member this.TotalRuns with get() = runs and set(v) = runs <- v
    [<DataMember>]
    member this.TotalWickets with get() = wickets and set(v) = wickets <- v
    [<DataMember>]
    member this.TotalVictims with get() = victims and set(v) = victims <- v
