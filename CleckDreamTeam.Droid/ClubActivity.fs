
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

[<Activity (Label = "Bradford League Club")>]
type ClubActivity() =
    inherit Activity()

    override x.OnCreate(bundle) =
        base.OnCreate (bundle)
        // Create your application here

        x.SetContentView(Resource_Layout.Club)

        let id = x.Intent.Extras.GetString(Intent.ExtraText)
        getClub id
            (fun club -> x.FindViewById<TextView>(Resource_Id.clubName).Text <- club.Name
                         x.FindViewById<TextView>(Resource_Id.clubRuns).Text <- sprintf "%d runs this season" club.Runs
                         x.FindViewById<TextView>(Resource_Id.clubWickets).Text <- sprintf "%d wickets this season" club.Wickets
                         x.FindViewById<TextView>(Resource_Id.clubVictims).Text <- sprintf "%d victims this season" club.Victims)
            ()
