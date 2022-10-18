module Slate

open Fable.Core
open Fable.React
open Feliz

type ReactEditor = interface end

type Text = {
    text: string
}

[<Erase>]
type Descendant =
    | Element of {| children: Descendant array |}
    | Text of {| text: string |}

// type Element = {
//     children: Descendant array
// }

[<Import("createEditor", from="slate")>]
let createEditor (): ReactEditor = jsNative

[<ReactComponent("Editable", from="slate-react")>]
let Editable (props: {| placeholder: string |}) : ReactElement = jsNative

[<ReactComponent("Slate", from="slate-react")>]
let Slate (props: {| editor: ReactEditor; value: Descendant array; children: #seq<ReactElement> |}): ReactElement = jsNative

[<Import("withReact", from="slate-react")>]
let withReact (editor: ReactEditor): ReactEditor = jsNative

[<Import("useSlate", from="slate-react")>]
let useSlate (createEditor: unit -> ReactEditor): ReactEditor = jsNative
