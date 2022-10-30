namespace Slate

open Fable.Core

type IEditableProp = interface end
type ISlateProp = interface end

type IEditor =
    abstract member children: obj array
    abstract member marks: obj
type Editor = inherit IEditor

[<Erase>]
type Descendant =
    | Element of {| children: Descendant array |}
    | Text of {| text: string |}

