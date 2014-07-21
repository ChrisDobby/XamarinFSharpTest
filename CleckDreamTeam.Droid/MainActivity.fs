namespace CleckDreamTeam.Droid

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity (Label = "Cleck Dream Team", MainLauncher = true)>]
type MainActivity () =
    inherit TabActivity ()

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resource_Layout.Main)

        [|"Players", typedefof<PlayersActivity>; "Clubs", typedefof<ClubsActivity> |] |>
               Seq.iter(fun tab -> let l, a = tab
                                   this.TabHost.AddTab(this.TabHost.NewTabSpec(l).SetIndicator(l).SetContent(new Intent(this,a))))

