const client = new stitch.StitchClient('entertainme-kjfts');
const db = client.service('mongodb', 'mongodb-atlas').db('blog');

function displayComments() {
  db.collection('comments').find({}).execute().then(docs => {
    var html = docs.map(c => '<div>' + c.comment + '</div>').join('');
    document.getElementById('comments').innerHTML = html;
  });
}

function displayCommentsOnLoad() {
  client.login().then(displayComments)
}

function addComment() {
  var c = document.getElementById('new_comment');
  db.collection('comments').insertOne({owner_id : client.authedId(),
                                       comment: c.value})
    .then(displayComments);
    c.value = '';
 }
 