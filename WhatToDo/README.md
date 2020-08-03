# What To Do

A C# application that maintains a list of tasks. There are
three projects in this solution:

**What2DoDL** - Data layer. It's probably overkill in this instance
but it allows me to change the data handling without making major
changes to the application. This project includes two classes:

- Task describes a task that must be done.
- Tasks maintains a list of Task objects. It is responsible for
  saving and loading a list of tasks stored in a generic List<Task>
  collection. The class also calls the List<Task> object to add and
  remove Task objects from the list.

**What2DoDLTests** - Contains the unit tests for WhatToDoDL.

**WhatToDo** - The UI portion of the application. It uses the classes
defined in What2DoDL to display and manage the list of tasks.
