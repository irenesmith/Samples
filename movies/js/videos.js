const client = new stitch.StitchClient('entertainme-kjfts');
const db = client.service('mongodb', 'mongodb-atlas').db('entertainment');

$(document).ready(function() {
  client.login().then(displayVideos)
});

$("#searchTitle").on("click", function(e) {
  var titleSearch = $("#titleToFind").val();

  displayVideosByTitle(titleSearch);
});

function displayVideos() {
  // Create the string that represents the table
  // contents. Calls to getFieldVals are for those
  // fields that might contain an array, a single
  // string, or be undefined.
  db.collection('videos').find({}).sort({'title': 1}).execute().then(docs => {
    var vidList = docs.map(v => '<tr><td>' +
      isDigital(v.hasvudu) + '</td><td>' +
      getTitle(v.collection, v.title) + '</td><td>' +
      getFieldVals(v.director) + '</td><td>' +
      v.format + '</td><td>' +
      v.year + '</td><td>' +
      getFieldVals(v.genre) + '</td><td>' +
      v.owner +
      '</td></tr>').join('');
    $('#videos').html(vidList);
    $('#videoCount').html(docs.length);
  });
}

function displayVideosByTitle(titleToFind) {
  // Create the string that represents the table
  // contents. Calls to getFieldVals are for those
  // fields that might contain an array, a single
  // string, or be undefined.
  var query = new RegExp(titleToFind);
  db.collection('videos').find({"title": query}).sort({'title': 1}).execute().then(docs => {
    var vidList = docs.map(v => '<tr><td>' +
      isDigital(v.hasvudu) + '</td><td>' +
      getTitle(v.collection, v.title) + '</td><td>' +
      getFieldVals(v.director) + '</td><td>' +
      v.format + '</td><td>' +
      v.year + '</td><td>' +
      getFieldVals(v.genre) + '</td><td>' +
      v.owner +
      '</td></tr>').join('');
    $('#videos').html(vidList);
    $('#videoCount').html(docs.length);
  });
}

function getTitle(collection, title) {
  // If there's a collection, combine it with
  // the title. Otherwise, just return the title.
  if (collection === undefined)
    return title;
  else
    return collection + '<br>' + title;
}

function isDigital(vudu) {
  if (vudu === true)
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

