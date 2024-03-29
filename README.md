# Samples

This repository contains code samples and documentation samples
created by Irene Smith.

toc::[]

## Documentation Samples

The documents folder contains sample documentation and links to additional examples
on MDN Web Docs.

- **modal** - A step-by-step tutorial that shows how to create and display
  a modal dialog box over the web page. The tutorial is in index.html.

- **BeginningWebDevelopment** - is a Microsoft Word document that (in this
  repo) discusses the parts of an HTML page. The articles were written early
  this year as part of a potential book on web development. There is also a PDF
  copy of the document.

- **[How to Search](https://wiki.developer.mozilla.org/en-US/docs/Tools/Debugger/How_to/Search)** - An article on MDN Web Docs that describes the search capabilities of the Firefox JavaScript Debugger. As of July 30, 2020, the page lists me as the last to edit it on October 15, 2019.

- **[Element: mousedown event](https://developer.mozilla.org/en-US/docs/Web/API/Element/mousedown_event)** - is an MDN Web Docs page describing the event handler for the mousedown event. The reference was written as part of an initiative to document all event handlers.

The page describes the mousedown event and the accompanying JavaScript example
uses the mousedown, musemove, and mouseup event handlers to let the reader draw
using the mouse. To keep the example simple, it only draws. There is no eraser
and no ability to change the drawing color or the pen thickness.

## Mouse Events

A very simple example of using [mouse events](mouse_event/) to draw on an HTML
canvas using the mouse. It doesn't have any ability to change pen color or
thickness. It was written simply to show how to handle events in vanilla
JavaScript.

## SnipMan

This is a Python application that I created back in 2012 to track the tasks and
projects I was working on while I was a contractor at Google. Employees were
required to submit a list of the tasks they completed during the week. This app
allowed me to create the file as I was working on it during the week. It helped
me to remember what I had worked on so I could report it accurately.

I have since added JavaScript and Visual Basic .NET versions of the application
just for fun.

- [SnipManJS](snipman/SnipManJS) - The JavaScript version of SnipMan
- [snipManPython](snipman/SnipManPython) - Contains two versions of the program
  - [SnipMan Python v1](snipman/SnipManPython/snipManv1) - The original snipman
    program created in 2012
  - [SnipMan Python v2](snipman/SnipManPython/snipManv2) - A slightly updated
    version of the program attempting
    to implement SnipMan using best practices for Python.
- [SnipManVB](snipman/SnipManVB) - Snipman written for Visual Basic .NET

## Spiromania

[Spiromania](spiromania/) draws images similar to the old Spirograph game that was popular in the 60s and
70s. It is based on a sample application written in Delphi by Jeff Duntemann.

## Stuff2Do

The web app [Stuff2Do](stuff2do/) is a jQuery example that manages a simple To Do list. Tasks
are stored in local storage rather than in a database just to keep the
application simple. It was written as a learning exercise.

## Tipster

[Tipster](tipster/) calculates the tip at a restaurant. Allows users to set the number of diners, and
the percentage that the use wants to tip.

## WhatToDo

[What To Do](WhatToDo/) is similar to Stuff2Do. It is a C# Windows Desktop application that
maintains a list of tasks. In this case, tasks are stored in a text file. on
the user's computer.

⚠️ I did not create an installer for this application. You must copy the code
to your computer and compile it yourself.

## Yacht

[Yacht](yacht/) is a game similar to Yahtzee written in JavaScript.
