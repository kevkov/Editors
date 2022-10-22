﻿namespace Slate

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Editor =
    static member inline create() : #IEditor = unbox (Interop.createEditor ())

[<Erase>]
type Editable =
    static member inline create(props: IEditableProp seq) =
        Interop.reactApi.createElement (Interop.editable, createObj !!props)

    static member inline placeHolder(placeholder: string) : IEditableProp =
        Interop.mkEditableProp "placeholder" placeholder

[<Erase>]
type Slate =
    static member inline create(props: ISlateProp seq) =
        Interop.reactApi.createElement (Interop.slate, createObj !!props)

    static member inline editor(editor: IEditor) : ISlateProp = Interop.mkSlateProp "editor" editor

    static member inline value(value: Descendant array) : ISlateProp = Interop.mkSlateProp "value" value

    static member inline children(children: ReactElement list) = unbox<ISlateProp> (prop.children children)
    
    static member inline withReact(editor: IEditor) = Interop.withReact(editor)