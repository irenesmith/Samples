#!/usr/bin/python

import tkinter
import datetime


def GetSnipFileName():
    # Get the snippet file name base on
    # the date of the next Monday. Even if
    # today is Monday, we mean "next Monday"
    # or 7 days from now.
    Today = datetime.date.today()
    days_to_monday: int = 7 - Today.weekday()
    if days_to_monday == 0:
        days_to_monday = 7
    tmp_file_name = "snips" + str(Today + datetime.timedelta(days=days_to_monday)) + ".txt"
    return tmp_file_name


class SnippetManager(tkinter.Tk):
    def __init__(self, parent):
        tkinter.Tk.__init__(self, parent)
        self.snipList = None
        self.newSnip = None
        self.snipText = None
        self.label_text = None
        self.parent = parent
        self.is_editing = False
        self.editIndex = 0
        self.initialize()

    def initialize(self):
        self.grid()

        self.label_text = tkinter.StringVar()

        newLabel = tkinter.Label(self, textvariable=self.label_text, anchor="w", fg="white", bg="blue")
        newLabel.grid(column=0, row=0, columnspan=2, sticky='EW')
        self.label_text.set("Welcome to snipMan v1.0")

        # The text box to enter new snippets.
        self.snipText = tkinter.StringVar()
        self.newSnip = tkinter.Entry(self, textvariable=self.snipText)
        self.newSnip.grid(column=0, row=1, sticky='EW')
        self.newSnip.bind("<Return>", self.OnPressEnter)
        self.snipText.set("Enter a new snippet here.")

        # The button that adds a new snippet to the list.
        addSnip = tkinter.Button(self, text="Add Snippet", command=self.OnButtonClick)
        addSnip.grid(column=1, row=1)

        self.grid_columnconfigure(0, weight=1)
        self.resizable(True, True)
        self.update()
        self.newSnip.focus_set()
        self.newSnip.selection_range(0, tkinter.END)

        # The list of existing snippet values.
        self.snipList = tkinter.Listbox(self, selectmode=tkinter.SINGLE, width=35)
        self.snipList.grid(column=0, row=2, columnspan=2, sticky='NSEW')
        self.snipList.bind('<ButtonRelease-1>', self.OnListItemClick)

    # Send the list of Snippets to weekly@google.com
    # as soon as I figure out how to send email with
    # python, that is.
    def send_snippets(self):
        # SUBJECT = "Snippet for Irene Smith"
        # TO = "weekly@google.com"
        # FROM = "irenesmith@google.com"
        # Need to get the list of snippets and create
        # text = "" # This will be the contents of the message.
        pass

    def get_snippets(self):
        try:
            with open(GetSnipFileName(), "r") as fileIn:
                for lineIn in fileIn:
                    lineIn = lineIn.strip("\n")
                    self.snipList.insert(tkinter.END, lineIn)
        except IOError as e:
            pass

    # This method adds a new snippet to the list and
    # also saves the snippet to the file. If this is
    # a new snippet, it will be appended to the file
    # as well as being added to the listbox. On the
    # other hand, if the snippet is an existing
    # snippet, the existing item will be replaced
    # with the changed item and then the entire
    # list will be written out, replacing the file
    # that was on disk with the new contents.
    def AddSnippet(self):
        if self.is_editing:
            self.snipList.delete(self.editIndex)
            self.snipList.insert(self.editIndex, self.newSnip.get())
            self.is_editing = False
            self.editIndex = 0
            fileOut = open(GetSnipFileName(), "w")
            for lineOut in self.snipList.get(0, tkinter.END):
                fileOut.write(lineOut + "\n")
            fileOut.close()
        else:
            self.snipList.insert(tkinter.END, self.newSnip.get())
            fileOut = open(GetSnipFileName(), "a")
            fileOut.write(self.newSnip.get() + "\n")
            fileOut.close()

        self.newSnip.focus_set()
        self.newSnip.selection_range(0, tkinter.END)

    # Adds the new snippet to the list and
    # also saves it to the file.
    def OnButtonClick(self):
        print("You pressed the button.")
        self.AddSnippet()

    # Adds the new snippet to the list and
    # also saves it to the file.
    def OnPressEnter(self, event):
        print("You pressed enter!!")
        self.AddSnippet()

    # Places the content of the snippet at
    # the location in the listbox where the
    # user clicked into the text box and also
    # sets self.IsEditing to True so that
    # file will be placed back in the list at
    # the same spot and the entire list will
    # be saved when the user is done.
    def OnListItemClick(self, event):
        print("You clicked a list item.")
        self.is_editing = True
        self.editIndex = self.snipList.curselection()[0]
        self.snipText.set(self.snipList.get(self.editIndex))
        print(self.snipText.get())


# Start of application
if __name__ == "__main__":
    app = SnippetManager(None)
    app.title("Snippet Manager 1.0")
    app.get_snippets()
    app.mainloop()
