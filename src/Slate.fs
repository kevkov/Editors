module Slate

open Fable.Core
open Fable.React

type ReactEditor = interface end

type Descendant =
    | Element
    | Text

type Element = {
    children: Descendant array
}

type Text = {
    text: string
}

[<Import("createEditor", from="slate")>]
let createEditor (): ReactEditor = jsNative

[<Import("Editable", from="slate-react")>]
let Editable (props: {| placeholder: string |}) : ReactElement = jsNative

[<Import("Slate", from="slate-react")>]
let Slate (props: {| editor: ReactEditor; value: Descendant array; children: ReactElement array |}): ReactElement = jsNative

[<Import("withReact", from="slate-react")>]
let withReact (editor: ReactEditor): ReactEditor = jsNative

[<Import("useSlate", from="slate-react")>]
let useSlate (createEditor: unit -> ReactEditor): ReactEditor = jsNative
