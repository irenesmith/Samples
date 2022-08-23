const client = new stitch.StitchClient('entertainme-kjfts');
const db = client.service('mongodb', 'mongodb-atlas').db('entertainment');

$(document).ready(function() {
  client.login().then(displayVideos);
});

function displayVideos() {
  // Create the string that represents each table
  // row. Calls to getFieldVals are for those
  // fields that might contain an array, a single
  // string, or undefined.
  db.collection('books').find({}).sort({'title': 1}).execute().then(docs => {
    var bookList = docs.map(b => getRow(b)).join('');

    // fill in the table
    $('#books').html(bookList);

    // Fill in the span with the number of books.
    $('#bookCount').html(docs.length);
  });
}

$("#bookTable").on("click", "tr", function(e) {
  // Get the book for this Id value.
  var selected = getBookById($(this).attr('id'));


});

$("#searchTitle").on("click", function(e) {
  var titleSearch = $("#titleToFind").val();
  found = getBooksByTitle(titleSearch);
  if(found.length > 1) {
    alert("Found " + found.length + " books.");
  }
});

function getRow(book) {
  var row = '<tr id="' + book._id + '"><td>' +
    isTrue(book.fiction) + '</td><td>' +
    isTrue(book.read) + '</td><td>' +
    getTitle(book.series, book.title) + '</td><td>' +
    getFieldVals(book.author) + '</td><td>' +
    book.year + '</td><td>' +
    book.pages + ' pages</td><td>' +
    book.format + '</td><td>' +
    getDescription(book.fiction, book.subject, book.genre, book.description) +
    '</td></tr>'
    return row
  }

function getTitle(series, title) {
  // If there's a collection, combine it with
  // the title. Otherwise, just return the title.
  if (series === undefined)
    return title;
  else
    return series + '<br>' + title;
}

function isTrue(boolVal) {
  if (boolVal === true)
    return '<img src="img/check.png" />'
  else
    return '';
}

function getFieldVals(val) {
  // Rather than have "undefined" in my table
  // simply replace the value with an empty string.
  if(val == undefined) {
    return '';
  }

  // On the other hand, if it's an array
  // return a comma-delimited list of values
  // with new lines.
  // --------------------------------------------
  // TODO: Consider making the separator a value
  // that can be defined by the caller so that
  // you could have a simple comma-delimited list
  // or a list with new lines in between.
  // --------------------------------------------
  if(Array.isArray(val)) {
    var vString = '';
    for(var i = 0; i < val.length; i++) {
      vString += val[i];
      if(i < val.length - 1)
        vString += ",<br>";
    }
    return vString;
  }

  // If it's not undefined and not an array
  // just return the value.
  return val;
}

function getDescription(isFiction, subject, genre, description) {
  var descriptionString;

  if(isFiction) {
    descriptionString = getFieldVals(genre) + '<br>';
  } else {
    descriptionString = getFieldVals(subject) + '<br>';
  }

  descriptionString += description;
  return descriptionString;
}

function getBooksByTitle(titleToFind) {
  var regex = BSON.BSONRegExp(titleToFind, 'i');
  db.collection('books').find({ title: { $regex: regex } }).execute().then(docs => {
    var bookList = docs.map(b =>  getRow(b)).join('');

    //return bookList;
    // fill in the table
    $('#books').html(bookList);

  });
}

function getBookById(id) {
  //db.collection('books').find({'title': 'How to Write Science Fiction and Fantasy'}).sort({'title': 1}).execute().then(docs => {
  var _id = _bsontype.createFromHexString(id);
  
  db.collection('books').find(_id).sort({'title': 1}).execute().then(docs => {
    var newBook = docs.map(b => createBook(b)).join('');
    return newBook;
  });
}

function createBook(book) {
  var newBook = new Book();
  newBook.Title = book.title;
  newBook.Author = book.author;
  newBook.Format = book.format;
  return newBook;
}

// Book class
function Book() {
  this.Id = '';
  this.Title = '';
  this.Author = '';
  this.Format = 'paperback';
  this.IsFiction = false;
  this.HasRead = false;
  this.Pages = 0;
  this.Subject = '';
  this.Genre = '';
  this.Description = ''
  this.Year = 1959;
}