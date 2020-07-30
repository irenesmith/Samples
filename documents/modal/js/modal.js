// Set up a variable for the dialog box
const dialog = document.querySelector('#dialog');
const overlay = document.querySelector('#overlay');

window.onload = (e) => {
  // Scroll to the top of the page
  window.scrollTo(0, 0);
  // Disable scrolling
  document.querySelector('body').className = 'noScroll';
};

// Add event listeners for the buttons.
document.querySelector('#xButton').addEventListener('click', closeDialog);
document.querySelector('#closeButton').addEventListener('click', closeDialog);
document.querySelector('#openButton').addEventListener('click', e => {
  document.querySelector('body').className = 'noScroll';
  overlay.className = 'overlay-on';
  dialog.className = 'dialog-on';
  document.querySelector('#openButton').disabled = true;
});

function closeDialog() {
  dialog.className = 'dialog-off';
  document.querySelector('#openButton').disabled = false;
  overlay.className = 'overlay-off';
  document.querySelector('body').className = 'canScroll';
}
