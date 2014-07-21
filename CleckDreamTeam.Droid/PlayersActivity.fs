
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

type PlayerListViewAdapter(context : Activity, players : Player[]) =
    inherit BaseAdapter()

    let sortedPlayers = players |> Array.filter(fun p -> not p.NotAvailable) |> Array.sortBy (fun p -> p.Surname)

    override x.GetItemId position =
        int64 sortedPlayers.[position].PlayerId

    override x.GetItem position =
        new Java.Lang.String (sortedPlayers.[position].Name) :> Java.Lang.Object        

    override x.Count = players |> Seq.length

    override this.GetView (position, convertView, parent) =
        let view = if not (convertView = null)
                   then convertView
                   else context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null)
        view.FindViewById<TextView>(Android.Resource.Id.Text1).Text <- sortedPlayers.[position].Name
        view.FindViewById<TextView>(Android.Resource.Id.Text2).Text <- sortedPlayers.[position].Club
        view

[<Activity (Label = "PlayersActivity")>]
type PlayersActivity() =
    inherit ListActivity()

    override x.OnCreate(bundle) =
        base.OnCreate (bundle)
        // Create your application here
        x.SetContentView (Resource_Layout.Players)

        x.ListView.FastScrollEnabled <- true
        getPlayers 
            (fun players -> x.ListAdapter <- new PlayerListViewAdapter(x, players))
            (Android.Widget.Toast.MakeText(x, "Unable to read players.  Check internet connection and try again", ToastLength.Short).Show())


    override x.OnListItemClick(l, v, position, id) =
        base.OnListItemClick(l, v, position, id)
        let intent = new Intent(x, typedefof<PlayerActivity>)
        intent.PutExtra(Intent.ExtraText, id.ToString()) |> ignore
        x.StartActivity(intent)
    