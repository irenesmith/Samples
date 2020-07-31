// Set up variables for the dialog box and its objects
const dialog = document.getElementById('dialog');
const overlay = document.getElementById('overlay');
const name = document.getElementById('name');
const email = document.getElementById('email');

// The two spans on the main page that will contain the
// values the user enters on the dialog box.
const userName = document.getElementById('username');
const userEmail = document.getElementById('useremail');

window.onload = (e) => {
  // Scroll to the top of the page
  window.scrollTo(0, 0);
  // Disable scrolling
  document.querySelector('body').className = 'noScroll';
};

// Add event listeners for the buttons.
document.getElementById('xButton').addEventListener('click', closeDialog);
document.getElementById('closeButton').addEventListener('click', closeDialog);
document.getElementById('openButton').addEventListener('click', e => {
  document.querySelector('body').className = 'noScroll';
  overlay.className = 'overlay-on';
  dialog.className = 'dialog-on';
  document.querySelector('#openButton').disabled = true;
});

function closeDialog() {
  userName.innerText = name.value;
  userEmail.innerText = email.value;
  dialog.className = 'dialog-off';
  document.querySelector('#openButton').disabled = false;
  overlay.className = 'overlay-off';
  document.querySelector('body').className = 'canScroll';
}
