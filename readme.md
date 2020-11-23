# Repro case for a weird thing with Uno.

## Description of project

The project consists of a simple MainPage, which has a datacontext of type `MainViewModel`.
In the `Load` event of the page, a `Task InitializeAsync()` is called, which waits 1 second, and then fills the `Items` property of the viewmodel, with 5 `DataItems`.

Each `DataItem` has a `Message` property set, to `One` through `Five`.

The Page contains an `ItemsControl`, databound to the `Items` property. The `DataTemplate` of the Item

If you run the project (I tried both GTK and WPF endpoints), you'll see `Hello World`', and 5 labels (One... Five) below that.
If you look at the console window, you'll see messages in the format of:

`<Index> in DataItemChanged. newValue.Type = <Type>, [Message = '<Message>']`

These messages are emitted in the `PropertyChanged` of the `DataItem` property of `TestControl`, which is used to present the values.
`TestControl` keeps a counter, where each instance gets a new number, this is shown in `<Index>` of the message.

`<Type>` shows the type of the databound value. If `<Type>` is `TestUnoApp.MyDataItem` (the correct one), the last part of the log message is shown, with the value of `<Message>`

## What this demo shows

As we can see in the output of the app, the controls first get their correct values, but then they get the `MainViewModel` instance as value, and then they revert back to the correct value.
In this sample it doesn't hurt performance too much, but in my real project, I can see this switching much more often.

## Uno versions tested

- 3.2.0
- 3.3.0