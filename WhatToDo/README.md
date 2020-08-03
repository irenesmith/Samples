# What To Do

A C# application that maintains a list of tasks. There are
three projects in this solution:

**What2DoDL** - Data layer. It's probably overkill in this instance
but it allows me to change the data handling without making major
changes to the application. This project includes two classes:

- **Task** describes a task that must be done.
- **Tasks** maintains a list of **Task** objects. It is responsible for
  saving and loading a list of tasks and exposing them to the UI.
  The Items property is a stored in a generic _List<Task>_collection.

**WhatToDo** - The UI portion of the application. It uses the classes
defined in What2DoDL to display and manage the list of tasks. Contains
two forms:

- FormMain - the main application form
- AboutBox - the About box for the application, deliberately simple.

**What2DoDLTests** - Contains the unit tests for WhatToDoDL.
