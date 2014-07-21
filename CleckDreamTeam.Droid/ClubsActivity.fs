
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

type ClubListViewAdapter(context : Activity, clubs : Club[]) =
    inherit BaseAdapter()

    let sortedClubs = clubs |> Array.filter(fun c -> not c.NotAvailable) |> Array.sortBy (fun c -> c.Name)

    override x.GetItemId position =
        int64 sortedClubs.[position].ClubId

    override x.GetItem position =
        new Java.Lang.String (sortedClubs.[position].Name) :> Java.Lang.Object        

    override x.Count = clubs |> Seq.length

    override this.GetView (position, convertView, parent) =
        let view = if not (convertView = null)
                   then convertView
                   else context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null)
        view.FindViewById<TextView>(Android.Resource.Id.Text1).Text <- sortedClubs.[position].Name
        view.FindViewById<TextView>(Android.Resource.Id.Text2).Text <- sprintf "division %d" sortedClubs.[position].Division
        view

[<Activity (Label = "ClubsActivity")>]
type ClubsActivity() =
    inherit ListActivity()

    override x.OnCreate(bundle) =
        base.OnCreate (bundle)
        // Create your application here
        x.SetContentView (Resource_Layout.Clubs)

        getClubs (fun clubs -> x.ListAdapter <- new ClubListViewAdapter(x, clubs)) 
            (Android.Widget.Toast.MakeText(x, "Unable to read clubs.  Check internet connection and try again", ToastLength.Short).Show())

    override x.OnListItemClick(l, v, position, id) =
        base.OnListItemClick(l, v, position, id)
        let intent = new Intent(x, typedefof<ClubActivity>)
        intent.PutExtra(Intent.ExtraText, id.ToString()) |> ignore
        x.StartActivity(intent)
    