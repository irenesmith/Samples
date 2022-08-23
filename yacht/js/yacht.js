// Global constants
const NUM_DICE = 5;
const MAX_MOVES = 13;
const rollButton = document.getElementById('roll-button');
const ERR_SCORE_ONCE = 'You can only enter a score in this box once.';
const ERR_MUST_SCORE = 'You must select a box to post your score.';
const ERR_ROLL_FIRST = 'You must roll the dice before you can post a score.';
const PLEASE_ROLL = 'Please roll the dice.';
const ROLL_AGAIN = 'Please roll again or select the item you wish to score.';
const SELECT_SCORE = 'Please select the item you wish to score.';

// Global variables
var isPlaying = false;
var currentPlayer = 1;
var playerMoves = [0, 0, 0, 0];
var rollCount = 0;
var numPlayers = 4;

var dice = [];

window.onload = (e) => {
  // First initialize the dice
  dice = initDice(NUM_DICE);

  // Add listeners to the dice
  for(let i = 0; i < NUM_DICE; i++) {
    document.getElementById(i).addEventListener('click', e => {
      if (dice[e.target.id].keep) {
        dice[e.target.id].keep = false;
        e.target.setAttribute('class', 'die');
      } else {
        dice[e.target.id].keep = true;
        e.target.setAttribute('class', 'keep');
      }
    });
  }

  // Add a listener for the splash screen
  let splash = document.getElementById('splash');
  splash.addEventListener('click', () => {
    splash.className = 'splash-off';
    document.getElementById('userInfo').setAttribute('open', '');
  });

  // Add a listener for the user dialog
  document.getElementById('btnOk').addEventListener('click', e => {
    let playerForm = document.getElementById('userInfo');
    numPlayers = parseInt(document.getElementById('num-players').value);
    for(let i = 1; i <= numPlayers; i++) {
      let name = document.getElementById('p' + i.toString()).value;
      document.getElementById('player' + i.toString()).textContent = name;
    }
    document.getElementById('userInfo').removeAttribute('open');
  initGame();
  });

  initScoreCard();
};

function initScoreCard() {
  // Attach listeners for the score card
  for (let i = 1; i <= 6; i++) {
    document.getElementById('s' + i).addEventListener('click', scoreClick);
  }
  document.getElementById('3kind').addEventListener('click', scoreClick);
  document.getElementById('4kind').addEventListener('click', scoreClick);
  document.getElementById('sstraight').addEventListener('click', scoreClick);
  document.getElementById('lstraight').addEventListener('click', scoreClick);
  document.getElementById('full-house').addEventListener('click', scoreClick);
  document.getElementById('yacht').addEventListener('click', scoreClick);
  document.getElementById('chance').addEventListener('click', scoreClick);

  rollButton.addEventListener('click', function (e) {
      rollClick();
  });
}

// Start a new game
function initGame() {
  isPlaying = true;
  currentPlayer = 1;
  playerMoves = [0,0,0,0];
  clearScoreCard();
  document.getElementById('rolls').textContent = PLEASE_ROLL;
}

// Empty all slots in the score card
function clearScoreCard() {
  let cells = document.getElementsByClassName('score');
  for(let i = 0; i < cells.length; i++) {
    cells[i].textContent = '';
  }
}

// ------------------------------------------
//   Game play routines
// ------------------------------------------

// Roll the dice up to three times in each turn
// making sure to only roll the dice that havent
// been selected to hold.
function rollClick() {
  if(rollCount >= 3) {
    alert(ERR_MUST_SCORE);
    return;
  }

  rollDice('img/', NUM_DICE, dice);
  rollCount++;

  rollCount === 3 ? document.getElementById('rolls').textContent = SELECT_SCORE : document.getElementById('rolls').textContent = ROLL_AGAIN;

}

// This function handles the click event for each of
// the score card positions. It also bubbles up to
// the row in the score card of which the clicked
// element is a member.
function scoreClick(e) {
  // Just in case the player tries to score on
  // the previous player's dice.
  if(rollCount < 1) {
    alert(ERR_ROLL_FIRST);
    return;
  }

  let scoreVal = 0;

  // Pull off the part of the element name that
  // tells us what the player is trying to score
  let scoreStr = (e.target.id).substring(0,1) != 'p' ?
    e.target.id : (e.target.id).substring(3);
  
  // Get the score value (which could be 0) for
  // the box on which the player clicked.
  switch(scoreStr) {
    case '1':
    case '2':
    case '3':
    case '4':
    case '5':
    case '6':
      scoreVal = scoreNum(parseInt(scoreStr, 10));
      break;
    case '3kind':
      scoreVal = scoreThreeKind();
      break;
    case '4kind':
      scoreVal = scoreFourKind();
      break;
    case 'full-house':
      scoreVal = scoreFullHouse();
      break;
    case 'sstraight':
      scoreVal = scoreSStraight();
      break;
    case 'lstraight':
      scoreVal = scoreLStraight();
      break;
    case 'yacht':
      scoreVal = scoreYacht();
      break;
    case 'chance':
      scoreVal = scoreChance();
      break;
  }

  // It doesn't matter which of the columns the
  // player clicked on. Just select the correct
  // box to add the score for that player.
  let scoreBoxId = 'p' + currentPlayer + '-' + scoreStr;
  let scoreBox = document.getElementById(scoreBoxId);

  // If they play more than one game, the score
  // boxes will have empty strings rather than
  // undefined, so check for both.
  if(scoreBox.innerText === '' || scoreBox.innerText == undefined) {
    scoreBox.innerText = scoreVal;
    sumTop();
    sumBottom();
    sumGrandTotal();
    playerMoves[currentPlayer] += 1;

    // Now that we're done with the scoring part
    // get ready for the next player.
    nextPlayer();

    // At the beginning of the turn, none of the
    // dice should be held, so set keep to false
    // for all five dice.
    clearHold();
  } else {
    alert(ERR_SCORE_ONCE);
  }

  // If the board is filled, the game is over.
  let moves = 0;
  for (let i = 1; i <= numPlayers; i++) {
    moves += playerMoves[i];
  }

  if (moves >= (MAX_MOVES * numPlayers)) {
    isPlaying = false;
    let highScore = 0;
    let winner = '';
    for (let i = 1; i <= numPlayers; i++) {
      let testValue = parseInt(document.getElementById('p' + i.toString() + 'Total').textContent);
      if (testValue > highScore) {
          highScore = testValue;
          winner = document.getElementById('player' + i.toString()).textContent;
        }
      }

    alert(`${winner} wins with a score of ${highScore}!`);
    document.getElementById('userInfo').setAttribute('open', '');
  }
}

function checkValue(elementId) {
  let temp = 0;
  if (document.getElementById(elementId).textContent != undefined) {
    temp = parseInt(document.getElementById(elementId).textContent);
  }
  return isNaN(temp) ? 0 : temp;
}

function sumTop() {
  let sum = 0, temp = 0;
  for(let i = 0; i < 6; i++) {
    let scoreBoxId = 'p' + currentPlayer + '-' + (i + 1);
    sum += checkValue(scoreBoxId);
  }

  // Fill in the top sub-total
  document.getElementById('p' + currentPlayer + '-sub-total').textContent = sum;

  // If the sub-total is equal to or more than 63
  // add 35 points to the top total
  if(sum >= 63) {
    document.getElementById('p' + currentPlayer + '-bonus').textContent = 35;
    sum += 35;
  }

  // Now fill in the top total
  document.getElementById('p' + currentPlayer + '-top-total').textContent = sum;
}

function sumBottom() {
  let sum = 0;

  sum = checkValue('p' + currentPlayer + '-3kind');
  sum += checkValue('p' + currentPlayer + '-4kind');
  sum += checkValue('p' + currentPlayer + '-full-house');
  sum += checkValue('p' + currentPlayer + '-sstraight');
  sum += checkValue('p' + currentPlayer + '-lstraight');
  sum += checkValue('p' + currentPlayer + '-yacht');
  sum += checkValue('p' + currentPlayer + '-chance');

  document.getElementById('p' + currentPlayer + '-bottom-total').textContent = sum > 0 ? sum : '';
}

function sumGrandTotal() {
  let sum = checkValue('p' + currentPlayer + '-top-total');
  sum += checkValue('p' + currentPlayer + '-bottom-total');

  document.getElementById('p' + currentPlayer + '-grand-total').textContent = sum;
  document.getElementById('p' + currentPlayer + 'Total').textContent = sum;
}

function countDice() {
  let diceCount = [0, 0, 0, 0, 0, 0];

  for (let i = 0; i < NUM_DICE; i++) {
    diceCount[dice[i].value - 1] += 1;
  }
  return diceCount;
}

function scoreNum(n) {
  let sum = 0;
  for(let i = 0; i < NUM_DICE; i++) {
    if(dice[i].value == n) {
      sum += n;
    }
  }
  return sum;
}

function scoreThreeKind() {
  let diceCount = countDice();

  // Looks for 3, 4, or 5 of a kind.
  let sum = 0;
  for(let i = 0; i < 6; i++) {
    if(diceCount[i] >= 3) {
      for(let i = 0; i < NUM_DICE; i++) {
        sum += dice[i].value;
      }
    }
  }
  return sum;
}

function scoreFourKind() {
  let diceCount = countDice();

  // Looks for 4 or 5 of a kind.
  let sum = 0;
  for (let i = 0; i < 6; i++) {
    if (diceCount[i] >= 4) {
      for (let i = 0; i < NUM_DICE; i++) {
        sum += dice[i].value;
      }
    }
  }
  return sum;
}

function scoreFullHouse() {
  let diceCount = countDice();

  if ((diceCount.indexOf(3) > -1) && (diceCount.indexOf(2) > -1)) {
    return 25;
  }
 
  return 0;
}

function scoreYacht() {
  let diceCount = countDice();

  // Now check for five of a kind
  if (diceCount.indexOf(5) > -1) {
    return 50;
  } else {
    return 0;
  }
}

function scoreSStraight() {
  let diceCount = countDice();
  let lower = true;
  let middle = true;
  let upper = true;

  // check lower then middle then upper to see
  // if the appropriate values are at least one.
  // i - 1 because the array is, of course, zero-based.
  for (let i = 1; i <= 4; i++) if (dice[i - 1] == 0) lower = false;
  for (let i = 2; i <= 5; i++) if (dice[i - 1] == 0) middle = false;
  for (let i = 3; i <= 6; i++) if (dice[i - 1] == 0) upper = false;

  return upper || middle || lower ? 30 : 0;
}

function scoreLStraight() {
  let diceCount = countDice();
  let lower = true;
  let upper = true;

  // Assure all dice counts are ones for lower or upper
  // i - 1 because the array is, of course, zero-based.
  for (let i = 1; i <= 5; i++) if (diceCount[i - 1] == 0) lower = false;
  for (let i = 2; i <= 6; i++) if (diceCount[i - 1] == 0) upper = false;

  return lower || upper ? 40 : 0;
}

function scoreChance() {
  let sum = 0;
  for(let i = 0; i < NUM_DICE; i++) {
    sum += dice[i].value;
  }
  return sum;
}

// Clear the highlight for the current player and
// then highlight the new player.
function nextPlayer() {
  // Clear the "active" class from the current user.
  document.getElementById('player' + currentPlayer).className = '';
  document.getElementById('scores' + currentPlayer).className = '';

  // Now increment the current player.
  currentPlayer++;
  if(currentPlayer > numPlayers) currentPlayer = 1;

  // Now highlight the new player
  document.getElementById('player' + currentPlayer).className = 'active';
  document.getElementById('scores' + currentPlayer).className = 'active';

  // Finally, if it's next player, the rollCount needs
  // to be reset so the person has three rolls too.
  rollCount = 0;
  document.getElementById('rolls').textContent = PLEASE_ROLL;
}

// At the beginning of the turn, none of the
// dice should be held, so set keep to false
// for all five dice.
function clearHold() {
  for(let i = 0; i < NUM_DICE; i++) {
    dice[i].keep = false;
    document.getElementById(i).className = 'die';
  }
}
