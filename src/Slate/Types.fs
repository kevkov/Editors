namespace Slate

open Fable.Core

type IEditableProp = interface end
type ISlateProp = interface end

type IEditor = interface end
type Editor = inherit IEditor

[<Erase>]
type Descendant =
    | Element of {| children: Descendant array |}
    | Text of {| text: string |}

