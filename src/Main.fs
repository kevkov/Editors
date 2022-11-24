module Main
open App.Components

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

ReactDOM.render(
    Editors(),
    document.getElementById "feliz-app"
)