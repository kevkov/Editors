namespace App

open Feliz
open type Html
open Feliz.Router
open Feliz.Quill
open Browser.Types

type Components =
    /// <summary>
    /// The simplest possible React component.
    /// Shows a header with the text Hello World
    /// </summary>
    [<ReactComponent>]
    static member Editors() =
        let editorRef = React.useRef<Element>(null)
        let editor = Quill.editor [
            prop.ref (fun e -> editorRef.current <- e) :?> IQuillEditorProperty
            editor.onTextChanged (fun x -> Fable.Core.JS.console.log(editorRef))
            editor.toolbar Toolbar.all
            editor.placeholder "Start some awesome story..."
        ]
        editor
        

    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let count, setCount = React.useState(0)
        div [
            h1 count
            button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Increment"
            ]
        ]

    /// <summary>
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>
    [<ReactComponent>]
    static member Router() =
        let (currentUrl, updateUrl) = React.useState(Router.currentUrl())
        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [ ] -> Html.h1 "Index"
                | [ "hello" ] -> Components.Editors()
                | [ "counter" ] -> Components.Counter()
                | otherwise -> Html.h1 "Not found"
            ]
        ]