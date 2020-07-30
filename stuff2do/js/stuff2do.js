var todoList = [];

$(document).ready(function() {
	// if the list exists, read it from local
	// storage and add it to the table.
	todoList = getTodoList();
	if ((typeof todoList != "undefined") && (todoList != null)) {
		// Fill the table.
		todoList.forEach(addToTable);
	};
	clearForm();
});

$("#task-table").on("click", "tr", function(e) {
	// Create a new task object.
	var selected = new Task();

	// Set the values from the table row.
	selected.dateCreated = $(this).attr('id');
	selected.status = this.cells[0].textContent;
	selected.description = this.cells[1].textContent;

	fillForm(selected);
	$("#add-task").val('Update Task');
});

$('#add-task').click(function() {
	if($("#description").val() == "") {
		alert("No value in description!");
	} else {
		var newTask = new Task();
		newTask.status = $("#status :selected").text();
		newTask.description = $("#description").val();

		// If #created is empty, it's a new
		// task. Otherwise, it's an existing
		// task and the lists need to be updated.
		if ($('#created').val() == '') {
			addToList(newTask);
			addToTable(newTask);			
		} else {
			newTask.dateCreated = $('#created').val();
			updateList(newTask);
			updateTable(newTask);
		}

		// Now that we're done, clear the form.
		clearForm();
	}
});

// Respond to clicks on the Cancel button.
$('#cancel').click(function() {
	clearForm();
});

// Get an existing list from local storage
function getTodoList() {
	var tasks = [];
	if (('localStorage' in window) && (window['localStorage'] !== null)) {
		tasks = JSON.parse(localStorage.getItem('todoList'));
	};
	return tasks;
}

// Save a changed list back to local storage
function setTodoList() {
	if (('localStorage' in window) && (typeof todoList != "undefined")) {
		localStorage.setItem('todoList', JSON.stringify(todoList));
	}
}

// Remove the entire list.
function removeTodoList() {
	if('localStorage' in window) {
		localStorage.removeItem('todoList');
	}
}

// Add a new task to the table
function addToTable(aTask) {
	var tableRow = '<tr id="' + aTask.dateCreated + '">';
	tableRow += "<td>" + aTask.status + "</td>";
	tableRow += "<td>" + aTask.description + "</td></tr>";
	$("#todo-list").append(tableRow);
}

// Update an existing task in the table
function updateTable(aTask) {
	var tableRow = '<tr id="' + aTask.dateCreated + '">';
	tableRow += "<td>" + aTask.status + "</td>";
	tableRow += "<td>" + aTask.description + "</td></tr>";

	$("#" + aTask.dateCreated).replaceWith(tableRow);
}

// Add a new task to the in-memory list and save it
function addToList(aTask) {
	// Add new task to list
	if ((typeof todoList == "undefined") || (todoList == null)) {
		todoList = [];
	}
	todoList.push(aTask);

	// Save the contents of the list
	setTodoList();
}

// Update an existing item in the list
function updateList(aTask) {
	for (var i = 0; i < todoList.length;  i++) {
		if (todoList[i].dateCreated == aTask.dateCreated) {
			todoList[i].status = aTask.status;
			todoList[i].description = aTask.description;
			setTodoList();
			break;
		}
	}
}

// Fill the form with an existing task.
function fillForm(aTask) {
	$('[name=status] option').filter(function() {
		return ($(this).text() == aTask.status);
	}).prop('selected', true);
	$('#description').val(aTask.description);
	$("#created").val(aTask.dateCreated);
}

// Clear the form.
function clearForm() {
	$('#created').val("");
	$('#description').val("");
	$('[name=status] option').filter(function() {
		return ($(this).text() == 'To Do');
	}).prop('selected', true);
	$("#add-task").val('Add Task');
}

// Task Class
function Task() {
	this.status = '';
	this.description = '';
	this.dateCreated = Date.now();
}