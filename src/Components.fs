namespace App

open Feliz
open type Html

open Feliz.Router
open Feliz.Quill
open Slate

type Components =
    /// <summary>
    /// The simplest possible React component.
    /// Shows a header with the text Hello World
    /// </summary>
    [<ReactComponent>]
    static member Editors() =
        let quill =
            Quill.editor [
                editor.onTextChanged (fun x -> Fable.Core.JS.console.log (x))
                editor.toolbar Toolbar.all
                editor.placeholder "Start some awesome story..."
            ]

        let editor, _ =
            React.useState (Slate.withReact (Editor.create ()))

        let slate =
            Slate.create [
                Slate.editor editor
                Slate.value [|
                    Element
                        {|
                            children =
                                [|
                                    Text {| text = "foo bar" |}
                                    Text {| text = "baz" |}
                                |]
                        |}
                |]
                Slate.children [
                    Html.div [
                        prop.className "toolbar"
                        prop.children [
                            Edit.markButton "bold" "format_bold"
                            Edit.markButton "bold" "format_bold"
                        ]
                    ]
                    Editable.create [
                        Editable.placeHolder "hello"
                        Editable.onKeyDown (fun _ -> Fable.Core.JS.console.log editor.children)
                    ]
                ]
            ]

        React.fragment [
            Html.div [
                prop.className "wrapper"
                prop.children [ slate ]
            ]
        ]


    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let count, setCount = React.useState (0)

        div [
            h1 count
            button [
                prop.onClick (fun _ -> setCount (count + 1))
                prop.text "Increment"
            ]
        ]

    /// <summary>
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>
    [<ReactComponent>]
    static member Router() =
        let (currentUrl, updateUrl) =
            React.useState (Router.currentUrl ())

        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [] -> Html.h1 "Index"
                | [ "hello" ] -> Components.Editors()
                | [ "counter" ] -> Components.Counter()
                | otherwise -> Html.h1 "Not found"
            ]
        ]
