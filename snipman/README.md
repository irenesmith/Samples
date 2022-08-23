# SnipMman Demo Applications

This project was originally created to manage the projects I was working on
as a contractor at Google in New York City. Version 1.0 of [SnipMan](snipManPython/snipManV1/)
was created as a learning exercise when I was teaching myself development in
the Python language. Now I will be porting the little application to multiple
languages including the latest version of Python, C#, and JavaScript.

## SnipMan Python version 1.0

Used to track completed tasks; a project to learn Python; this is my first
Python application. It creates a text file to which "snippets" can be added.
The file name is the date of the next Monday. If today is Mondy, the file
will be dated with today's date.

If a file with that name already exists, it will be opened to add new items
to the file. The simple interface was created with TKinter.

## SnipMan VB version 1.0

Performs the same functions as the original Python SnipMan using Visual Basic,
.NET Core 6.0 and the Windows Forms library. I think the UI is cleaner looking
than the interface using Tkinter.

As with the Python version of SnipMan, this application calculates the date of
the previous Monday. Instead of storing the file in the same folder as the
application, it saves the file in the Documents folder. This is easy to do with
.NET because the library includes an enumeration that gives access to standard
system folders such as Documents and Downloads.

If the file already exists, it is opened to add new items to the file. The
interface for the VB.NET version uses the Windows Forms library.

## SnipMan JS version 1.0

This is the JavaScript version of SnipMan.

The UI for this application was created using the latest version of HTML and
styled using Bootstrap 5.1.3 rather than a hand-coded design.

The code uses jQuery to manage the list of snippets. To simplify the application,
snippets are stored in local storage, meaning that the saved data is specific to
a single computer.
