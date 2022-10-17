module Slate

open Fable.Core

type IEditor = interface end

[<Import("createEditor", from="slate")>]
let createEditor (): IEditor = jsNative

