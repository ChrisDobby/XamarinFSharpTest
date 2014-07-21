
namespace CleckDreamTeam.Droid

open System
open System.Collections.Generic
open System.Linq
open System.Text

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open CleckDreamTeam.Droid.Utilities

[<Activity (Label = "Bradford League Player")>]
type PlayerActivity() =
    inherit Activity()

    override x.OnCreate(bundle) =
        base.OnCreate (bundle)
        // Create your application here

        x.SetContentView(Resource_Layout.Player)

        let id = x.Intent.Extras.GetString(Intent.ExtraText)
        getPlayer id
            (fun player -> x.FindViewById<TextView>(Resource_Id.playerName).Text <- player.Name
                           x.FindViewById<TextView>(Resource_Id.playerClub).Text <- player.Club
                           x.FindViewById<TextView>(Resource_Id.playerRuns).Text <- sprintf "%d runs" player.TotalRuns
                           x.FindViewById<TextView>(Resource_Id.playerWickets).Text <- sprintf "%d wickets" player.TotalWickets 
                           x.FindViewById<TextView>(Resource_Id.playerVictims).Text <- sprintf "%d victims" player.TotalVictims)
            ()

