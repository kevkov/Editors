namespace Slate

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkEditableProp (key: string) (value: obj) : IEditableProp = unbox (key, value)
    let inline mkSlateProp (key: string) (value: obj) : ISlateProp = unbox (key, value)

    let editable : obj = import "Editable" "slate-react"
    let slate : obj = import "Slate" "slate-react"
    
    let createEditor (): obj = import "createEditor" "slate"    
    let withReact (editor: IEditor): IEditor = import "withReact" "slate-react"
