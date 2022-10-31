namespace Slate

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkEditableProp (key: string) (value: obj) : IEditableProp = unbox (key, value)
    let inline mkSlateProp (key: string) (value: obj) : ISlateProp = unbox (key, value)

    type Slate =
        static member createEditor (): obj = import "createEditor" "slate"

    type SlateReact =
        static member Editable : obj = import "Editable" "slate-react"
        static member Slate : obj = import "Slate" "slate-react"

        static member withReact (editor: IEditor): IEditor = import "withReact" "slate-react"

